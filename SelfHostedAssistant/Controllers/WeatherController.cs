using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SelfHostedAssistant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : Controller
    {
        [HttpGet("CurrentWeather")]
        public async Task<IActionResult> CurrentWeather(string lat, string lon)
        {
            var darkSky = new DarkSky.Services.DarkSkyService("770e26e6dcc0c7b7b76439d3ab7f9e98");
            var forecast = await darkSky.GetForecast(42.915, -78.741);
            if (forecast?.IsSuccessStatus == true)
            {
                return Ok(forecast.Response.Currently);
            }
            return BadRequest($"Error getting weather");
        }


        [Route("HourlyForecast")]
        [HttpGet]
        public async Task<IActionResult> HourlyForecast(string lat, string lon)
        {
            var darkSky = new DarkSky.Services.DarkSkyService("770e26e6dcc0c7b7b76439d3ab7f9e98");
            var forecast = await darkSky.GetForecast(42.915, -78.741);
            if (forecast?.IsSuccessStatus == true)
            {
                return Ok(forecast.Response.Hourly);
            }
            return BadRequest($"Error getting weather");
        }
    }
}
