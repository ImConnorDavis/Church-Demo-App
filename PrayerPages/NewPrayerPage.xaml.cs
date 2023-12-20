using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace Church_Demo.PrayerPages;

public partial class NewPrayerPage : ContentPage
{
    [BsonElement("NewName")]
    public string NewName { get; set; }
    [BsonElement("NewPrayerContents")]
    public string NewPrayerContents { get; set; }
    [BsonElement("NewisAnonymous")]
    public string NewisAnonymous { get; set; }

    public NewPrayerPage()
	{
		InitializeComponent();
        BindingContext = this;
    }
    async void SaveCommand(System.Object sender, System.EventArgs e)
    {
        //try
        //{
        //    try
        //    {
        //        var settings = MongoClientSettings.FromConnectionString("mongodb+srv://BeyondUnited:BrigandConnor@prayerrequests.9wr50hy.mongodb.net/?retryWrites=true&w=majority");
        //        var client = new MongoClient(settings);
        //        var database = client.GetDatabase("PrayerRequests");
        //        var collection = database.GetCollection<BsonDocument>("Prayers");
        //        NewName = MainPage.MyName;
        //        NewisAnonymous = isAnonymousSwitch.IsToggled.ToString();
        //        if (NewPrayerContents != null)
        //        {
        //            var document = new BsonDocument
        //        {
        //            {"Name", NewName },
        //            {"PrayerContents", NewPrayerContents },
        //            {"isAnonymous", NewisAnonymous},
        //        };
        //            await collection.InsertOneAsync(document);
        //        }
        //        await Navigation.PopAsync();
        //    }
        //    catch
        //    {
        //        var settings = MongoClientSettings.FromConnectionString("mongodb://BeyondUnited:BrigandConnor@ac-kdudtc3-shard-00-00.9wr50hy.mongodb.net:27017,ac-kdudtc3-shard-00-01.9wr50hy.mongodb.net:27017,ac-kdudtc3-shard-00-02.9wr50hy.mongodb.net:27017/?ssl=true&replicaSet=atlas-5uj7c1-shard-0&authSource=admin&retryWrites=true&w=majority");
        //        var client = new MongoClient(settings);
        //        var database = client.GetDatabase("PrayerRequests");
        //        var collection = database.GetCollection<BsonDocument>("Prayers");
        //        NewName = MainPage.MyName;
        //        NewisAnonymous = isAnonymousSwitch.IsToggled.ToString();
        //        if (NewPrayerContents != null)
        //        {
        //            var document = new BsonDocument
        //        {
        //            {"Name", NewName },
        //            {"PrayerContents", NewPrayerContents },
        //            {"isAnonymous", NewisAnonymous},
        //        };
        //            await collection.InsertOneAsync(document);
        //        }
        //        await Navigation.PopAsync();
        //    }
        //    //var client = new MongoClient(settings);
        //    //Console.WriteLine("Step 2");
        //    //var database = client.GetDatabase("PrayerRequests");
        //    //Console.WriteLine("step 3");
        //    //var collection = database.GetCollection<BsonDocument>("Prayers");
        //    //Console.WriteLine("step 4");
        //    //NewName = MainPage.MyName;
        //    //NewisAnonymous = isAnonymousSwitch.IsToggled.ToString();
        //    //if (NewPrayerContents != null)
        //    //{
        //    //    var document = new BsonDocument
        //    //    {
        //    //        {"Name", NewName },
        //    //        {"PrayerContents", NewPrayerContents },
        //    //        {"isAnonymous", NewisAnonymous},
        //    //    };
        //    //    await collection.InsertOneAsync(document);
        //    //}
        //    //await Navigation.PopAsync();
        //}
        //catch
        //{
        //    Console.WriteLine("FAILLLURE");
        //}
    }
}
