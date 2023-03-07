using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("WeatherForecast")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };


        public WeatherForecastController()
        {
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            WeatherForecast[] weathers =
            {
                new WeatherForecast
                {
                    Date = DateTime.Now,
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = "Lusine"
                },
                new WeatherForecast
                {
                    Date = DateTime.Now,
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                },
                new WeatherForecast
                {
                    Date = DateTime.Now,
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                }
            };

            return weathers;
        }
    }
}