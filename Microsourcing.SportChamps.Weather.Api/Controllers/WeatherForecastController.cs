using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsourcing.SportChamps.Weather.Model.Others;
using Microsourcing.SportChamps.Weather.Model.Weather;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Microsourcing.SportChamps.Weather.Api.Controllers
{
    [EnableCors("Forecast")]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly AppConfig _config;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOptions<AppConfig> options, IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _logger = logger;
            _config = options.Value;
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetForecast")]
        /// <summary>
        /// Gets the 16-days span weather forecast
        /// </summary>
        /// <returns>Returns weather forecast</returns>
        public async Task<IActionResult> GetForecast(string city, int days = 16)
        {
            if (string.IsNullOrWhiteSpace(city)) return new StatusCodeResult(400);

            var client = _httpClientFactory.CreateClient();

            var uri = $"{_config.WeatherMapAPIUrl}?q={city}&limit=1&appid={_config.APIKey}";
            var locations = await client.GetFromJsonAsync<List<GeoLocation>>(uri);
            var loc = locations.FirstOrDefault();

            uri = $"{_config.WeatherAPIUrl}?lat={loc.lat}&lon={loc.lon}&units=metric&exclude=hourly,minutely,current,alerts&appid={_config.APIKey}";
            var forecast = await client.GetFromJsonAsync<WeatherForecast>(uri);

            var forecastDTO = new WeatherForecastDTO();
            var dailyDTO = _mapper.Map<List<DailyDTO>>(forecast.daily);
            forecastDTO.daily = dailyDTO;

            return new JsonResult(forecastDTO);
        }
    }
}
