namespace Microsourcing.SportChamps.Weather.Model.Others
{
    public class AppConfig
    {
        public string WeatherAPIUrl { get; set; } = "https://api.openweathermap.org/data/2.5/onecall";
        public string WeatherMapAPIUrl { get; set; } = "http://api.openweathermap.org/geo/1.0/direct";
        public string APIKey { get; set; } = "82e1a9baf46d78bf3ac368ec48b7ebbb";
    }
}
