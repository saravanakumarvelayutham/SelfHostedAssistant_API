using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using SelfHostedAssistant.Models;

namespace SelfHostedAssistant.Services
{
    public class EventService : IEventService
    {
        private readonly IMongoCollection<Event> _events;
        public EventService(IAssistantDatabaseSettings settings)
        {
            var mongo_uri = Environment.GetEnvironmentVariable("MONGODB_URI");
            Console.WriteLine(mongo_uri);
            if (string.IsNullOrEmpty(mongo_uri))
            {
                mongo_uri = settings.ConnectionString;
            }
            var client = new MongoClient(mongo_uri + "?retryWrites=false");
            var databaseName = mongo_uri.Split('/').Last();
            var database = client.GetDatabase(databaseName);

            _events = database.GetCollection<Event>("Event");
        }

        public List<Event> Get() => _events.Find(@event => true).ToList();

        public Event Get(string id) =>
            _events.Find<Event>(@event => @event.id == id).FirstOrDefault();

        public Event Create(Event @event)
        {
            _events.InsertOne(@event);
            return @event;
        }

        public void Update(string id, Event eventIn) =>
            _events.ReplaceOne(@event => @event.id == id, eventIn);

        public void Remove(Event eventIn) =>
            _events.DeleteOne(@event => @event.id == eventIn.id);

        public void Remove(string id) =>
            _events.DeleteOne(@event => @event.id == id);
    }
}
