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
        
        [HttpGet]
        public IEnumerable<WeatherEvent> Get()
        {
            return _context.WeatherEvents.ToList();
          
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
          // return _context.WeatherEvents.Where(w => w.Type==WeatherType.Rain).ToList();
        return _context.WeatherEvents.Where(w => (int)w.Type==weatherType).ToList();
        }


        

    //[HttpPut]
        // public bool LogWeatherEvent(DateTime datetime, WeatherType type, bool happy)
        // {
        //     var wE = WeatherEvent.Create(datetime, type, happy);

        //     _context.WeatherEvents.Add(wE);
        //     var result = _context.SaveChanges();
        //     return result == 1;
        // }
    }
}