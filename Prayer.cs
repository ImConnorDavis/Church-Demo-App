using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Church_Demo
{
	public class Prayer
	{
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("PrayerContents")]
        public string PrayerContents { get; set; }
        [BsonElement("PostedName")]
        public string PostedName { get; set; }
    }
}

