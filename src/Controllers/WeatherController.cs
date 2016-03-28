using System;
using System.Collections.Generic;
using System.Linq;
using EFCoreWebAPI.Data;
using EFCoreWebAPI.Tools;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;


namespace EFCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        WeatherContext _context;
        public WeatherController(WeatherContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IEnumerable<WeatherEvent> Get()
        {
            return _context.WeatherEvents.Include(w => w.Reactions).ToList();

        }


        //api/Weather/2016-01-28
        [HttpGet("{date}")]
        public IEnumerable<WeatherEvent> Get(DateTime date)
        {
            return _context.WeatherEvents.Where(w => w.Date.Date == date.Date).ToList();
        }

        //api/Weather/1
        [HttpGet("{weatherType:int}")]
        public IEnumerable<WeatherEvent> Get(int weatherType)
        {
            return _context.WeatherEvents.FromSql($"SELECT * FROM EventsByType({weatherType})").OrderByDescending(e => e.Id);
            // return _context.WeatherEvents.Where(w => w.Type==WeatherType.Rain).ToList();
            //  return _context.WeatherEvents.Where(w => (int)w.Type==weatherType).ToList();
        }

        [HttpPost]
        public bool LogWeatherEvent(DateTime datetime, WeatherType type, bool happy)
        {
            var wE = WeatherEvent.Create(datetime, type, happy);

            _context.WeatherEvents.Add(wE);
            var result = _context.SaveChanges();
            return result == 1;
        }

        [HttpPost("{eventId}")]
        public string GetAndUpdateMostCommonWord(int eventId)
        {
            var eventGraph = _context.WeatherEvents
            .Include(w => w.Reactions).FirstOrDefault(w => w.Id == eventId);
            var theWord = ReactionParser.MostFrequentWord(
                eventGraph.Reactions.Select(r => r.Quote).ToList());
            eventGraph.MostCommonWord = theWord;

            return theWord;
        }

 

    }
    internal class InternalServices
    {
        WeatherContext _context;
        public InternalServices(WeatherContext context)
        {
            _context = context;
        }
        public void UpdateWeatherEventOnly(WeatherEvent weatherEvent)
        {
            //even if this is a graph, only root will get touched
            _context.Entry(weatherEvent).State = EntityState.Added;
            _context.SaveChanges();

        }
    }
}