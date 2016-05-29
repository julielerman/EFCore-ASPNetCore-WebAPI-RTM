using EFCoreWebAPI.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace EFCoreWebAPI.Internal
{
    //this is a little wonky but allows me to buid the demo more easily
    //to show disconnected graph being passed in 
    public class WeatherDataRepository
    {
        WeatherContext _context;
        public WeatherDataRepository(WeatherContext context)
        {
            _context = context;
        }
        internal void UpdateWeatherEventOnly(WeatherEvent weatherEvent)
        {
            //even if this is a graph, only root will get touched
            _context.Entry(weatherEvent).State = EntityState.Modified;
            _context.SaveChanges();

        }
        internal WeatherEvent GetWeatherEventAndReactionsById(int eventId)
        {
            return _context.WeatherEvents
              .Include(w => w.Reactions).FirstOrDefault(w => w.Id == eventId);
        }

        internal List<WeatherEvent> GetAllEventsWithReactions()
        {
            return _context.WeatherEvents
            .Include(w => w.Reactions).ToList();
        }
        internal int UpdateRandomStateWeatherEventGraphs(List<WeatherEvent> weatherEvents)
        {
            foreach (var graph in weatherEvents)
            {
                _context.ChangeTracker.TrackGraph(graph, e => ConvertStateOfNode(e));

            }
            return _context.SaveChanges();
        }

        private void ConvertStateOfNode(EntityEntryGraphNode node)
        {
            IState entity = (IState)node.Entry.Entity;
            node.Entry.State = ConvertToEFState(entity.ObjectState);
        }

        private EntityState ConvertToEFState(ObjectState objectState)
        {
            EntityState efState=EntityState.Unchanged;
            switch (objectState)
            {
                case ObjectState.Added:
                    efState= EntityState.Added;
                    break;
                case ObjectState.Modified:
                    efState= EntityState.Modified;
                     break;
                case ObjectState.Deleted:
                    efState= EntityState.Deleted;
                     break;
                case ObjectState.Unchanged:
                    efState= EntityState.Unchanged;
                     break;
            }
            return efState;
        }
    }
}