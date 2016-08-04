using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using JsonNet.PrivateSettersContractResolvers;
using EFCoreWebAPI.Data;

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