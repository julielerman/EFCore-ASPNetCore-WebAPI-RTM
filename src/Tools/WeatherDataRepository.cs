using EFCoreWebAPI.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
        internal  void UpdateWeatherEventOnly(WeatherEvent weatherEvent)
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
    } 
}