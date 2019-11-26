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
        [HttpPost]
        public IActionResult Post(double lat, double lon)
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
                return BadRequest("Error in updating Location paramters");

            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                lock (Location._locker)
                {
                    return Ok(new EventLocation() { latitude = Location.Latitude, longitude = Location.Longitude });
                }
            }
            catch
            {
                return BadRequest("Error getting Location");

            }
        }
    }
}