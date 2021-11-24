using System;
using System.Collections.Generic;

namespace Microsourcing.SportChamps.Weather.Model.Weather
{
    public class Daily
    {
        public long dt { get; set; }
        public long sunrise { get; set; }
        public long sunset { get; set; }
        public long moonrise { get; set; }
        public long moonset { get; set; }
        public decimal moon_phase { get; set; }

        public Temp temp { get; set; }
        public List<Weather> weather { get; set; }
    }

    public class DailyDTO
    {
        public long Date { get; set; }
        public long Sunrise { get; set; }
        public long Sunset { get; set; }
        public long MoonRise { get; set; }
        public long MoonSet { get; set; }
        public decimal Moon_Phase { get; set; }
        
        public Temp temp { get; set; }
        public List<Weather> Weather { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
    }

    public class Temp
    {
        public decimal day { get; set; }
        public decimal min { get; set; }
        public decimal max { get; set; }
        public decimal night { get; set; }
        public decimal eve { get; set; }
        public decimal morn { get; set; }
    }

    public class WeatherForecast
    {
        public string timezone { get; set; }
        public long timezone_offset { get; set; }

        public List<Daily> daily { get; set; }

        //public DateTime Date { get; set; }

        //public int TemperatureC { get; set; }

        //public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        //public string Summary { get; set; }
    }

    public class WeatherForecastDTO
    {
        public string timezone { get; set; }
        public long timezone_offset { get; set; }

        public List<DailyDTO> daily { get; set; }

        //public DateTime Date { get; set; }

        //public int TemperatureC { get; set; }

        //public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        //public string Summary { get; set; }
    }

    public class GeoLocation
    {
        public string name { get; set; }
        public decimal lat { get; set; }
        public decimal lon { get; set; }
        public string country { get; set; }
    }

    public class WeatherLocation
    {
        public List<GeoLocation> Location { get; set; }
    }
}
