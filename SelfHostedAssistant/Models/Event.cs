using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SelfHostedAssistant.Models
{
    public class Event
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement]
        public string Title { get; set; }

        [BsonElement]
        public DateTimeOffset start { get; set; }

        [BsonElement]
        public DateTimeOffset end { get; set; }
    }
}
