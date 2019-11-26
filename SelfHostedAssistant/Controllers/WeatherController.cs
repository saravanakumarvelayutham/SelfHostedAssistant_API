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
        public async Task<IActionResult> CurrentWeather(double lat, double lon)
        {
            var darkSky = new DarkSky.Services.DarkSkyService("770e26e6dcc0c7b7b76439d3ab7f9e98");
            var forecast = await darkSky.GetForecast(lat, lon);
            if (forecast?.IsSuccessStatus == true)
            {
                return Ok(forecast.Response.Currently);
            }
            return BadRequest($"Error getting weather");
        }

        [HttpGet("GetWeather")]
        public async Task<IActionResult> GetWeather(double lat, double lon, double unixTimeStamp)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();

            var darkSky = new DarkSky.Services.DarkSkyService("770e26e6dcc0c7b7b76439d3ab7f9e98");
            var forecast = await darkSky.GetForecast(lat, lon, new DarkSky.Models.OptionalParameters { ForecastDateTime = dtDateTime });
            if (forecast?.IsSuccessStatus == true)
            {
                return Ok(forecast.Response.Currently);
            }
            return BadRequest($"Error getting weather");
        }


        [Route("HourlyForecast")]
        [HttpGet]
        public async Task<IActionResult> HourlyForecast(double lat, double lon)
        {
            var darkSky = new DarkSky.Services.DarkSkyService("770e26e6dcc0c7b7b76439d3ab7f9e98");
            var forecast = await darkSky.GetForecast(lat, lon);
            if (forecast?.IsSuccessStatus == true)
            {
                return Ok(forecast.Response.Hourly);
            }
            return BadRequest($"Error getting weather");
        }
    }
}
