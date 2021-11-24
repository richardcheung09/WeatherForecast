using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsourcing.SportChamps.Weather.Model.Others;
using Microsourcing.SportChamps.Weather.Model.Weather;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Microsourcing.SportChamps.Weather.App.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AppConfig _config;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;

        public string city { get; set; }

        public WeatherForecastDTO forecast { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IOptions<AppConfig> options, IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _logger = logger;
            _config = options.Value;
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }

        public async Task OnGetAsync(string c)
        {
            var forecastDTO = new WeatherForecastDTO();

            //var dailyDTO = new List<DailyDTO>() { new DailyDTO() { temp = new Temp(), Weather = new List<Model.Weather.Weather>() { new Model.Weather.Weather() } } };
            var dailyDTO = new List<DailyDTO>();
            forecastDTO.daily = dailyDTO;
            
            //if (string.IsNullOrEmpty(c))
            //{
            //    this.forecast = forecastDTO;
            //    return;
            //}

            //city = c;

            //var client = _httpClientFactory.CreateClient();

            //var uri = $"{_config.WeatherMapAPIUrl}?q={city}&limit=1&appid={_config.APIKey}";
            //var locations = await client.GetFromJsonAsync<List<GeoLocation>>(uri);
            //var loc = locations.FirstOrDefault();

            //uri = $"{_config.WeatherAPIUrl}?lat={loc.lat}&lon={loc.lon}&units=metric&exclude=hourly,minutely,current,alerts&appid={_config.APIKey}";
            //var forecast = await client.GetFromJsonAsync<WeatherForecast>(uri);

            //dailyDTO = _mapper.Map<List<DailyDTO>>(forecast.daily);
            //forecastDTO.daily = dailyDTO;

            this.forecast = forecastDTO;
        }
    }
}