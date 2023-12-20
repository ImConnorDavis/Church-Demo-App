using MongoDB.Bson;
using MongoDB.Driver;

namespace Church_Demo.AdminPages;

public partial class CreateEventPage : ContentPage
{
	public CreateEventPage()
	{
		InitializeComponent();
	}
	async void EventPostBtn_Clicked(System.Object sender, System.EventArgs e)
	{
		try
		{
			var settings = MongoClientSettings.FromConnectionString("mongodb://BeyondUnited:BrigandConnor@ac-kdudtc3-shard-00-00.9wr50hy.mongodb.net:27017,ac-kdudtc3-shard-00-01.9wr50hy.mongodb.net:27017,ac-kdudtc3-shard-00-02.9wr50hy.mongodb.net:27017/?ssl=true&replicaSet=atlas-5uj7c1-shard-0&authSource=admin&retryWrites=true&w=majority");
			var client = new MongoClient(settings);
			var database = client.GetDatabase("Events");
			var collection = database.GetCollection<BsonDocument>("Events");
			string EventName = EventNameBox.Text;
			string EventDetails = EventDetailBox.Text;
			string EventDateSet = EventDateBox.Date.ToShortDateString();
			string EventTimeSet = EventTimeBox.Time.ToString();
			string EventDate = EventDateSet;
			string EventTime = EventTimeSet;
			if (EventName != null)
			{
				var document = new BsonDocument
				{
					{"EventName", EventName },
					{"EventDetails", EventDetails },
					{"EventDate", EventDate},
					{"EventTime", EventTime},
				};
				await collection.InsertOneAsync(document);
			}
			await Navigation.PopAsync();
		}
		catch
		{
			var settings = MongoClientSettings.FromConnectionString("mongodb://BeyondUnited:BrigandConnor@ac-kdudtc3-shard-00-00.9wr50hy.mongodb.net:27017,ac-kdudtc3-shard-00-01.9wr50hy.mongodb.net:27017,ac-kdudtc3-shard-00-02.9wr50hy.mongodb.net:27017/?ssl=true&replicaSet=atlas-5uj7c1-shard-0&authSource=admin&retryWrites=true&w=majority");
			var client = new MongoClient(settings);
			var database = client.GetDatabase("Events");
			var collection = database.GetCollection<BsonDocument>("Events");
			string EventName = EventNameBox.Text;
			string EventDetails = EventDetailBox.Text;
			string EventDateSet = EventDateBox.Date.ToShortDateString();
			string EventTimeSet = EventTimeBox.Time.ToString();
            string EventDate = EventDateSet;
            string EventTime = EventTimeSet;
			if (EventName != null)
			{
				var document = new BsonDocument
				{
					{"EventName", EventName },
					{"EventDetails", EventDetails },
					{"EventDate", EventDate},
                    {"EventTime", EventTime},
                };
				await collection.InsertOneAsync(document);
			}
			await Navigation.PopAsync();
		}
	}
}
