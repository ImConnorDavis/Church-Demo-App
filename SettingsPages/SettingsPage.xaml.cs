using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Church_Demo.SettingsPages;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
        On<iOS>().SetUseSafeArea(false);
        NameFrame.BackgroundColor = Color.FromArgb(MainPage.ButtonColor);
        AdminFrame.BackgroundColor = Color.FromArgb(MainPage.ButtonColor);
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        NameLbl.Text = MainPage.MyName;
        if (MainPage.AdminCheck != null)
        {
            if (MainPage.AdminCheck == "true")
            {
                var settings = MongoClientSettings.FromConnectionString("mongodb://BeyondUnited:BrigandConnor@ac-kdudtc3-shard-00-00.9wr50hy.mongodb.net:27017,ac-kdudtc3-shard-00-01.9wr50hy.mongodb.net:27017,ac-kdudtc3-shard-00-02.9wr50hy.mongodb.net:27017/?ssl=true&replicaSet=atlas-5uj7c1-shard-0&authSource=admin&retryWrites=true&w=majority");
                var client = new MongoClient(settings);
                var database = client.GetDatabase("PrayerRequests");
                var collection = database.GetCollection<BsonDocument>("ManagementCode");
                var cursor = await collection.Find(new BsonDocument()).FirstOrDefaultAsync();
                BsonElement ManagementCodeSet;
                ManagementCodeSet = cursor.GetElement("Code");
                string ManagementCode = ManagementCodeSet.ToString().Replace("Code=", "");
                AdminCodeLbl.Text = "Admin Code: " + ManagementCode;
            }
        }
    }
    async void ManagementCodeBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        //MongoDB API to retrieve management code
        //var settings = MongoClientSettings.FromConnectionString("mongodb+srv://BeyondUnited:BrigandConnor@prayerrequests.9wr50hy.mongodb.net/?retryWrites=true&w=majority");
        var settings = MongoClientSettings.FromConnectionString("mongodb://BeyondUnited:BrigandConnor@ac-kdudtc3-shard-00-00.9wr50hy.mongodb.net:27017,ac-kdudtc3-shard-00-01.9wr50hy.mongodb.net:27017,ac-kdudtc3-shard-00-02.9wr50hy.mongodb.net:27017/?ssl=true&replicaSet=atlas-5uj7c1-shard-0&authSource=admin&retryWrites=true&w=majority");
        var client = new MongoClient(settings);
        var database = client.GetDatabase("PrayerRequests");
        var collection = database.GetCollection<BsonDocument>("ManagementCode");
        var cursor = await collection.Find(new BsonDocument()).FirstOrDefaultAsync();
        BsonElement ManagementCodeSet;
        ManagementCodeSet = cursor.GetElement("Code");
        string ManagementCode = ManagementCodeSet.ToString().Replace("Code=", "");
        Console.WriteLine("CODE GOTTEN: " + ManagementCode);
        string result = await DisplayPromptAsync("Management Code", "Please enter the five digit management code.");
        if (result != null)
        {
            //Check if management code is correct
            if (ManagementCode == result)
            {
                await SecureStorage.Default.SetAsync("AdminSet", "true");
            }
        }
    }
    async void ChangeNameBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        string result = await DisplayPromptAsync("What's Your Name?", "Lets set your name now.");
        if (result != null)
        {
            await SecureStorage.Default.SetAsync("MyName", result);
            MainPage.MyName = result;
            NameLbl.Text = result;
        }
        else
        {
        }
    }
}
