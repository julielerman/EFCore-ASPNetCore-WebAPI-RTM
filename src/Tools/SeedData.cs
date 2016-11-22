using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using JsonNet.PrivateSettersContractResolvers;
using EFCoreWebAPI.Data;
using Newtonsoft.Json.Linq;

namespace EFCoreWebAPI.Tools
{
    public class Seeder
    {
        WeatherContext _context;


        public Seeder(WeatherContext context)
        {
            _context = context;

        }

        public void Seedit(string jsonData)
        {

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = new PrivateSetterContractResolver()

            };
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            //json was hard coded with dates
            //editing the raw json to update dates to current date range
            //not doing that in weatherevent because date is protected
            List<JObject> random = JsonConvert.DeserializeObject<List<JObject>>(jsonData, settings);
            var day = System.DateTime.Today.AddDays(-1);
            foreach (var weatherEvent in random)
            {
                day = day.AddDays(1);
                weatherEvent["date"] = day;
            }
            jsonData = JsonConvert.SerializeObject(random);
            //dates now updated

            List<WeatherEvent> events =
           JsonConvert.DeserializeObject<List<WeatherEvent>>(jsonData, settings);

           if (!_context.WeatherEvents.Any())
            {
                _context.AddRange(events);
                _context.SaveChanges();
            }
        }
    }
}