using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SelfHostedAssistant.Models;

namespace SelfHostedAssistant.Controllers
{
    [Route("api/[controller]")]
    public class LocationController : Controller
    {
        [HttpGet]
        public IActionResult Get(double lat, double lon)
        {
            try
            {
                lock (Location._locker)
                {
                    Location.Latitude = lat;
                    Location.Longitude = lon;
                    return Ok("Location Updated");
                }
            }
            catch
            {
                return BadRequest("Updateing Location paramters");

            }
        }
    }
}