using System;
using System.Collections.Generic;

namespace EFCoreWebAPI
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
                wE._reactions.Add(new Reaction { Name = reaction[0], Quote = reaction[1] });
                Console.WriteLine($"Reactions Count {wE._reactions.Count}");
            }
            return wE;
        }
        
        public WeatherEvent() { 
            _reactions=new List<Reaction>();
        }

        private WeatherEvent(DateTime dateTime, WeatherType type, Boolean hooray)
        {
            this.Date = dateTime.Date;
            this.Time = dateTime.TimeOfDay;
            Hooray = hooray;
            Type = type;
            _reactions = new List<Reaction>();
            ObjectState=ObjectState.Added;
        }
        public int Id { get; set; }
        public DateTime Date { get; private set; }
        public TimeSpan Time { get; private set; }
        public WeatherType Type { get; private set; }
        public bool Hooray { get; private set; }
        private List<Reaction> _reactions;
        public IEnumerable<Reaction> Reactions { get {return _reactions;} }
        public  string MostCommonWord{get;set;}
        public ObjectState ObjectState {get;set;}
        public void AddReaction(string name, string quote){
            var reaction=new Reaction { 
                Name=name, Quote = quote,
                ObjectState=ObjectState.Added,WeatherEventId=this.Id};
            _reactions.Add(reaction);  
            
        }
        public void RemoveReaction(int reactionId){
           var reaction= _reactions.Find(r=>r.Id==reactionId);
           reaction.ObjectState=ObjectState.Deleted;
          _reactions.Remove(reaction);
        }

    }

    public class Reaction:IState
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Quote { get; set; }
        public int WeatherEventId { get; set; }
        public ObjectState ObjectState {get;set;}

    }
    public enum WeatherType
    {
        Rain = 1,
        Snow = 2,
        Sleet = 3,
        Hail = 4,
        Sun = 5
    }
    public interface IState
    {
        ObjectState ObjectState {get;set;}
    }
      public enum ObjectState
    {
        Unchanged=0,
       Added=1,
       Modified=2,
       Deleted=3
    }
}