using System;
using System.Collections.Generic;
using System.Linq;
using EF7WebAPI.Data;
using Microsoft.AspNet.Mvc;


namespace EF7WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        WeatherContext _context;
        public WeatherController(WeatherContext context)
        {
            _context = context;
        }
        // GET: api/values
        // [HttpGet]
        // public IEnumerable<WeatherEvent> Get(WeatherType type)
        // {
        //     return _context.WeatherEvents.Where(w => w.Type == type).ToList();
        // }
        [HttpGet]
        public IEnumerable<WeatherEvent> Get()
        {
            return _context.WeatherEvents.ToList();
        }

    //    [HttpGet]
    //       public IEnumerable<string> Get()
    //     {
    //         return new string[] { "value1", "value4" };
    //     }
        
        // [HttpGet]
        // public IEnumerable<WeatherEvent> Get(DateTime date)
        // {
        //     return _context.WeatherEvents.Where(w => w.Date.Date == date.Date).ToList();
        // }

        // [HttpGet]
        // public bool LogWeatherEvent(DateTime datetime, WeatherType type, bool happy)
        // {
        //     var wE = WeatherEvent.Create(datetime, type, happy);

        //     _context.WeatherEvents.Add(wE);
        //     var result = _context.SaveChanges();
        //     return result == 1;
        // }
    }
}