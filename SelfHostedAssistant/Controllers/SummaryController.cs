using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SelfHostedAssistant.Models;
using SelfHostedAssistant.Services;

namespace SelfHostedAssistant.Controllers
{
    [Route("api/[controller]")]
    public class SummaryController : Controller
    {
        private readonly IEventService _eventService;

        public SummaryController(IServiceProvider serviceProvider)
        {
            _eventService = (IEventService)serviceProvider.GetService(typeof(EventService));
        }
        public ActionResult<EventSummary> Index()
        {
            var currentDate = DateTimeOffset.Now;
            var eventList = _eventService.Get().ToList();
            var nextEvent = eventList.Where(x => currentDate < x.endDate).FirstOrDefault();
            if(nextEvent != null)
            {
                var eventSummary = new EventSummary { NextEvent = nextEvent, Summary = "Summary goes here" };
                return Ok(eventSummary);
            }
            return Ok(new EventSummary() { NextEvent = new Event(), Summary = "No events next" });
        }
    }

    public class EventSummary
    {
        public Event NextEvent { get; set; }

        public string Summary { get; set; }
    }
}