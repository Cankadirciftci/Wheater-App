using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


namespace HavaDurumuApi.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;

         public WeatherService(HttpClient httpClient)
         {
            _httpClient = httpClient;
         }
        
          public async Task<string> GetWeatherAsync(string cityName)
    {
        string apiKey = "98435693976f0dc91d8946688c36cd7a"; // OpenWeatherMap API anahtarınızı buraya ekleyin
        string url = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}&units=metric";

        var response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var data = await response.Content.ReadAsStringAsync();
            var weatherData = JObject.Parse(data);

            string description = weatherData["weather"][0]["description"].ToString();
            string temperature = weatherData["main"]["temp"].ToString();

            return $"City: {cityName}, Temperature: {temperature}°C, Description: {description}";
        }

        return $"Couldn't retrieve weather data for {cityName}";
    }
    }
}