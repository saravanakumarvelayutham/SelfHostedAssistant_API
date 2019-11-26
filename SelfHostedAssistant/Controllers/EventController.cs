using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SelfHostedAssistant.Models;
using SelfHostedAssistant.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SelfHostedAssistant.Controllers
{
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        private readonly EventService _eventService;

        public EventController(EventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public ActionResult<List<Event>> Get()
        {
            return _eventService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetEvent")]
        public ActionResult<Event> Get(string id)
        {
            var @event = _eventService.Get(id);

            if (@event == null)
            {
                return NotFound();
            }

            return @event;
        }

        [HttpPost]
        public ActionResult<Event> Create([FromBody]Event @event)
        {
            _eventService.Create(@event);

            return CreatedAtRoute("GetEvent", new { id = @event.id.ToString() }, @event);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, [FromBody]Event eventIn)
        {
            var @event = _eventService.Get(id);

            if (@event == null)
            {
                return NotFound();
            }

            _eventService.Update(id, eventIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var @event = _eventService.Get(id);

            if (@event == null)
            {
                return NotFound();
            }

            _eventService.Remove(@event.id);

            return NoContent();
        }
    }

    public class DateFilter
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
