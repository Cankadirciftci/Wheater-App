using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HavaDurumuApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HavaDurumuApi.Controlles
{
    public class WeatherController : ControllerBase
    {
        private readonly WeatherService _weatherService;

        public WeatherController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("{city}")]
        public async Task<IActionResult> GetWeather(string city)
        {
            var weatherInfo = await _weatherService.GetWeatherAsync(city);
            return Ok(weatherInfo);
        }
    }   
}