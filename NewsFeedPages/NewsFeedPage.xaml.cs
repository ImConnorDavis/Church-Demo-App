using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.ObjectModel;
using Syncfusion.Maui.PdfViewer;

namespace Church_Demo.NewsFeedPages;

public partial class NewsFeedPage : ContentPage
{
    public NewsFeedPage()
    {
        InitializeComponent();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var settings = MongoClientSettings.FromConnectionString("mongodb://BeyondUnited:BrigandConnor@ac-kdudtc3-shard-00-00.9wr50hy.mongodb.net:27017,ac-kdudtc3-shard-00-01.9wr50hy.mongodb.net:27017,ac-kdudtc3-shard-00-02.9wr50hy.mongodb.net:27017/?ssl=true&replicaSet=atlas-5uj7c1-shard-0&authSource=admin&retryWrites=true&w=majority");
        var client = new MongoClient(settings);
        var database = client.GetDatabase("News");
        var collection = database.GetCollection<BsonDocument>("News");
        var cursor = await collection.Find(new BsonDocument()).FirstOrDefaultAsync();
        BsonElement NewsPostSet;
        NewsPostSet = cursor.GetElement("pdfdata");
        string pdfdata = NewsPostSet.ToString().Replace("pdfdata=", "");
        byte[] pdfdatabytes = Convert.FromBase64String(pdfdata);
        Console.WriteLine(pdfdata);
        if (pdfdatabytes != null)
        {
            Stream pdfdatastream = new MemoryStream(pdfdatabytes);
            //pdfdatastream = await pdfdata.OpenReadAsync();
            pdfViewer.DocumentSource = pdfdatastream;
            pdfViewer.IsVisible = true;
        }
    }
}