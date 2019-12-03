using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private readonly IGoogleService _googleService;

        public SummaryController(IServiceProvider serviceProvider)
        {
            _eventService = (IEventService)serviceProvider.GetService(typeof(EventService));
            _googleService = (IGoogleService)serviceProvider.GetService(typeof(GoogleService));
        }
        public ActionResult<EventSummary> Index()
        {
            var currentDate = DateTimeOffset.Now;
            var eventList = _eventService.Get().ToList();
            var nextEvent = eventList.Where(x => currentDate < x.endDate).OrderBy(x=>x.startDate).FirstOrDefault();

            if (nextEvent != null)
            {
                var summary = new StringBuilder();
                if (nextEvent.location.latitude.HasValue && nextEvent.location.longitude.HasValue)
                {
                    var travelTime = _googleService.GetTravelTime(nextEvent.location.latitude.Value, nextEvent.location.longitude.Value);

                    _ = string.IsNullOrEmpty(travelTime.GetValueOrDefault().ToString()) == false ? summary.Append($"Travel Time to {nextEvent.title} - {nextEvent.location.address} : {travelTime} min(s)") : null;
                }
                var eventSummary = new EventSummary { nextEvent = nextEvent, summary = summary.ToString() };
                return Ok(eventSummary);
            }
            return Ok(new EventSummary() { nextEvent = new Event(), summary = "No events next" });
        }
    }

    public class EventSummary
    {
        public Event nextEvent { get; set; }

        public string summary { get; set; }
    }
}