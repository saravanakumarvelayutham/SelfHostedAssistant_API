using System.Collections.Generic;
using SelfHostedAssistant.Models;

namespace SelfHostedAssistant.Services
{
    public interface IEventService
    {
        Event Create(Event @event);
        List<Event> Get();
        Event Get(string id);
        void Remove(Event eventIn);
        void Remove(string id);
        void Update(string id, Event eventIn);
    }
}