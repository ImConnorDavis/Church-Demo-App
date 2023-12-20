using System;
using System.Collections.ObjectModel;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Church_Demo
{
	public class EventControl
	{
        private ObservableCollection<Event> events;
        public ObservableCollection<Event> Events
        {
            get { return events; }
            set
            {
                events = value;
            }
        }

        public EventControl()
		{
            try
            {
                var settings = MongoClientSettings.FromConnectionString("mongodb+srv://BeyondUnited:BrigandConnor@prayerrequests.9wr50hy.mongodb.net/?retryWrites=true&w=majority");
                var client = new MongoClient(settings);
                var database = client.GetDatabase("Events");
                var collection = database.GetCollection<BsonDocument>("Events");
                var cursor = collection.Find(new BsonDocument()).ToCursor();
                Events = new ObservableCollection<Event>();

                foreach (var document in cursor.ToEnumerable())
                {
                    BsonElement EventNameSet, EventDetailsSet, EventDateSet, EventTimeSet;
                    EventNameSet = document.GetElement("EventName");
                    EventDetailsSet = document.GetElement("EventDetails");
                    EventDateSet = document.GetElement("EventDate");
                    EventTimeSet = document.GetElement("EventTime");
                    //Add Anonymous Tickets
                    Events.Add(new Event()
                    {
                        EventName = EventNameSet.ToString().Replace("EventName=", ""),
                        EventDetails = EventDetailsSet.ToString().Replace("EventDetails=", ""),
                        EventDate = EventDateSet.ToString().Replace("EventDate=", ""),
                        EventTime = EventTimeSet.ToString().Replace("EventTime=", ""),
                    });
                }
            }
            catch
            {
                var settings = MongoClientSettings.FromConnectionString("mongodb://BeyondUnited:BrigandConnor@ac-kdudtc3-shard-00-00.9wr50hy.mongodb.net:27017,ac-kdudtc3-shard-00-01.9wr50hy.mongodb.net:27017,ac-kdudtc3-shard-00-02.9wr50hy.mongodb.net:27017/?ssl=true&replicaSet=atlas-5uj7c1-shard-0&authSource=admin&retryWrites=true&w=majority");
                var client = new MongoClient(settings);
                var database = client.GetDatabase("Events");
                var collection = database.GetCollection<BsonDocument>("Events");
                var cursor = collection.Find(new BsonDocument()).ToCursor();
                Events = new ObservableCollection<Event>();

                foreach (var document in cursor.ToEnumerable())
                {
                    BsonElement EventNameSet, EventDetailsSet, EventDateSet, EventTimeSet;
                    EventNameSet = document.GetElement("EventName");
                    EventDetailsSet = document.GetElement("EventDetails");
                    EventDateSet = document.GetElement("EventDate");
                    EventTimeSet = document.GetElement("EventTime");
                    //Add Anonymous Tickets
                    Events.Add(new Event()
                    {
                        EventName = EventNameSet.ToString().Replace("EventName=", ""),
                        EventDetails = EventDetailsSet.ToString().Replace("EventDetails=", ""),
                        EventDate = EventDateSet.ToString().Replace("EventDate=", ""),
                        EventTime = EventTimeSet.ToString().Replace("EventTime=", ""),
                    });
                }
            }
        }
	}
}

