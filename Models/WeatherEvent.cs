using System;

namespace EF7WebAPI
{
  public class WeatherEvent
  {
    public static WeatherEvent Create(DateTime date, WeatherType type, Boolean hooray) {
      return new WeatherEvent(date, type, hooray);
    }
    public WeatherEvent() {

    }
    private WeatherEvent(DateTime dateTime, WeatherType type, Boolean hooray) {
      this.Date = dateTime.Date;
      this.Time = dateTime.TimeOfDay;
      Hooray = hooray;
      Type = type;
    }
    public int Id { get; set; }
    public DateTime Date { get; private set; }

    public TimeSpan Time { get; private set; }

    public WeatherType Type { get; private set; }
    
    public bool Hooray { get; private set; }
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