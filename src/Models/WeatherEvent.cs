using System;
using System.Collections.Generic;

namespace EF7WebAPI
{
    public class WeatherEvent
    {
        public static WeatherEvent Create(DateTime date, WeatherType type, Boolean hooray)
        {
            return new WeatherEvent(date, type, hooray);
        }

        public static WeatherEvent Create(DateTime date, WeatherType type, Boolean hooray, List<string[]> reactions)
        {
            var wE = new WeatherEvent(date, type, hooray);
            foreach (var reaction in reactions)
            {
                wE.Reactions.Add(new Reaction { Name = reaction[0], Quote = reaction[1] });
                Console.WriteLine($"Reactions Count {wE.Reactions.Count}");
            }
            return wE;
        }
        
        public WeatherEvent() { }

        private WeatherEvent(DateTime dateTime, WeatherType type, Boolean hooray)
        {
            this.Date = dateTime.Date;
            this.Time = dateTime.TimeOfDay;
            Hooray = hooray;
            Type = type;
            Reactions = new List<Reaction>();
        }
        public int Id { get; set; }
        public DateTime Date { get; private set; }
        public TimeSpan Time { get; private set; }
        public WeatherType Type { get; private set; }
        public bool Hooray { get; private set; }
        public ICollection<Reaction> Reactions { get; set; }
    }

    public class Reaction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Quote { get; set; }
        public int WeatherEventId { get; set; }

    }
    public enum WeatherType
    {
        Rain = 1,
        Snow = 2,
        Sleet = 3,
        Hail = 4,
        Sun = 5
    }
}