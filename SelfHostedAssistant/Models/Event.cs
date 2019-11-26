using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SelfHostedAssistant.Models
{
    public class Event
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        [BsonElement]
        public string title { get; set; }

        [BsonElement]
        public string rrule { get; set; }

        [BsonElement]
        public string color { get; set; }
        
        [BsonElement]
        public DateTimeOffset startDate { get; set; }


        [BsonElement]
        public DateTimeOffset endDate { get; set; }

        [BsonElement]
        public EventLocation location { get; set; }
    }
}
