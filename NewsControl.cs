using System;
using System.Collections.ObjectModel;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Church_Demo
{
	public class NewsControl
	{
        private ObservableCollection<NewsPost> newsposts;
        public ObservableCollection<NewsPost> NewsPosts
        {
            get { return newsposts; }
            set
            {
                newsposts = value;
            }
        }
        public NewsControl()
		{
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://BeyondUnited:BrigandConnor@prayerrequests.9wr50hy.mongodb.net/?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("PrayerRequests");
            var collection = database.GetCollection<BsonDocument>("Prayers");
            var cursor = collection.Find(new BsonDocument()).ToCursor();
            NewsPosts = new ObservableCollection<NewsPost>();
        }
	}
}

