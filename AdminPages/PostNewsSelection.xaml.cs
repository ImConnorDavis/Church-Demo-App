using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Church_Demo.AdminPages;

public partial class PostNewsSelection : ContentPage
{
	public PostNewsSelection()
	{
		InitializeComponent();
        On<iOS>().SetUseSafeArea(false);
        BlankNewsPageBtn.BackgroundColor = Color.FromArgb(MainPage.ButtonColor);
        PDFNewsPostPageBtn.BackgroundColor = Color.FromArgb(MainPage.ButtonColor);
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var settings = MongoClientSettings.FromConnectionString("mongodb://BeyondUnited:BrigandConnor@ac-kdudtc3-shard-00-00.9wr50hy.mongodb.net:27017,ac-kdudtc3-shard-00-01.9wr50hy.mongodb.net:27017,ac-kdudtc3-shard-00-02.9wr50hy.mongodb.net:27017/?ssl=true&replicaSet=atlas-5uj7c1-shard-0&authSource=admin&retryWrites=true&w=majority");
        var client = new MongoClient(settings);
        var database = client.GetDatabase("News");
        var collection = database.GetCollection<BsonDocument>("News");
        if (collection.AsQueryable().Count() >= 1)
        {
            ActiveNews.IsVisible = true;
        }
    }
        async void BlankNewsPageBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new AdminPages.BlankNewsPage());
    }
    async void PDFNewsPostPageBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new AdminPages.PDFNewsPost());
    }
    async void ViewPDFBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new NewsFeedPages.NewsFeedPage());
    }
}
