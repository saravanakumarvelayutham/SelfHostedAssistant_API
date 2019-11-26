using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SelfHostedAssistant.Models;

namespace SelfHostedAssistant.Controllers
{
    [Route("api/[controller]")]
    public class CalendarImportController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody]CalendarFile calendarFile)
        {
            try
            {
                return Ok(calendarFile);
            }
            catch
            {
                return BadRequest("Calendar Import failed");
            }
        }
    }
}