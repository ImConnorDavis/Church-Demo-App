using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Church_Demo
{
	public class Event
	{
        [BsonElement("EventName")]
        public string EventName { get; set; }
        [BsonElement("EventDetails")]
        public string EventDetails { get; set; }
        [BsonElement("EventDate")]
        public string EventDate { get; set; }
        [BsonElement("EventTime")]
        public string EventTime { get; set; }
    }
}

