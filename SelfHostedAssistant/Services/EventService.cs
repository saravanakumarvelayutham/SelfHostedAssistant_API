using System;
using System.Collections.Generic;
using MongoDB.Driver;
using SelfHostedAssistant.Models;

namespace SelfHostedAssistant.Services
{
    public class EventService
    {
        private readonly IMongoCollection<Event> _events;
        public EventService(IAssistantDatabaseSettings settings)
        {
            var mongo_uri = Environment.GetEnvironmentVariable("MONGODB_URI");
            MongoClient client;
            if (string.IsNullOrEmpty(mongo_uri))
            {
                client = new MongoClient(settings.ConnectionString);
            }
            else client = new MongoClient(mongo_uri);
            var database = client.GetDatabase(settings.DatabaseName);
            
            _events = database.GetCollection<Event>("Event");
        }

        public List<Event> Get() =>
          _events.Find(@event => true).ToList();

        public Event Get(string id) =>
            _events.Find<Event>(@event => @event.Id == id).FirstOrDefault();

        public Event Create(Event @event)
        {
            _events.InsertOne(@event);
            return @event;
        }

        public void Update(string id, Event eventIn) =>
            _events.ReplaceOne(@event => @event.Id == id, eventIn);

        public void Remove(Event eventIn) =>
            _events.DeleteOne(@event => @event.Id == eventIn.Id);

        public void Remove(string id) =>
            _events.DeleteOne(@event => @event.Id == id);
    }
}
