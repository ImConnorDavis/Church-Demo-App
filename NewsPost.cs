using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Church_Demo
{
	public class NewsPost
	{
        [BsonElement("NewsPostContents")]
        public string NewsPostContents { get; set; }
    }
}

