namespace Church_Demo;
using System.Net;

using System.Net.Mail;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using Newtonsoft.Json.Linq;

public partial class MainPage : ContentPage
{
    public static string MyName { get; set; }
    public static string AdminCheck { get; set; }
    public static string ButtonColor { get; set; }

	public MainPage()
	{
        InitializeComponent();
        On<iOS>().SetUseSafeArea(false);
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        try
        {
            await Task.Delay(500); // Introduce a small delay (in milliseconds)
            MyName = await SecureStorage.Default.GetAsync("MyName");
            AdminCheck = await SecureStorage.Default.GetAsync("AdminSet");
            await SecureStorage.Default.SetAsync("ButtonColor", "#80FFFFFF");
            ButtonColor = await SecureStorage.Default.GetAsync("ButtonColor");
        }
        catch
        {
            ButtonColor = await SecureStorage.Default.GetAsync("ButtonColor");
        }

        //Set button colors
        //PrayerRequestsBtn.BackgroundColor = Color.FromArgb(MainPage.ButtonColor);
        //NewsFeedPageBtn.BackgroundColor = Color.FromArgb(MainPage.ButtonColor);
        //LiveFeedPageBtn.BackgroundColor = Color.FromArgb(MainPage.ButtonColor);
        //EventsPageBtn.BackgroundColor = Color.FromArgb(MainPage.ButtonColor);
        //MembersPageBtn.BackgroundColor = Color.FromArgb(MainPage.ButtonColor);
        //AdminPageBtn.BackgroundColor = Color.FromArgb(MainPage.ButtonColor);
        //SettingsPageBtn.BackgroundColor = Color.FromArgb(MainPage.ButtonColor);

        //Set ButtonColor on first open
        if (ButtonColor == null)
        {
            await SecureStorage.Default.SetAsync("ButtonColor", "#80FFFFFF");
            ButtonColor = await SecureStorage.Default.GetAsync("ButtonColor");
            PrayerRequestsBtn.BackgroundColor = Color.FromArgb(MainPage.ButtonColor);
        }
        //Run this if first app open to check for username
        try
        {
            if (MyName == null)
            {
                string result = await DisplayPromptAsync("What's Your Name?", "Lets set your name now, you can change this later in settings.");
                if (result != null)
                {
                    await SecureStorage.Default.SetAsync("MyName", result);
                    MyName = result;
                }
                else
                {
                    await SecureStorage.Default.SetAsync("MyName", "Anonymous");
                    MyName = "Anonymous";
                }
            }
            else
            {
                MyName = await SecureStorage.Default.GetAsync("MyName");
            }
            if (AdminCheck != null)
            {
                if (AdminCheck == "true")
                {
                    AdminPageBtn.IsVisible = true;
                }
            }
        }
        catch
        {
            MyName = "FAIL";
        }

        //--------Get Random Bible Verse-------------
        try
        {
            using (var client = new HttpClient())
            {
                var apiUrl = "https://labs.bible.org/api/?passage=random&type=json&callback=myCallback";
                var response = await client.GetStringAsync(apiUrl);

                // Remove the "myCallback(" prefix and ");" suffix to get the pure JSON data
                response = response.Replace("myCallback(", "").TrimEnd(')');

                // Parse the JSON data as a JArray
                JArray verseArray = JArray.Parse(response);

                if (verseArray.Count > 0)
                {
                    // Access the first item in the array
                    JObject verseData = (JObject)verseArray[0];

                    string bookname = (string)verseData["bookname"];
                    string chapter = (string)verseData["chapter"];
                    string verse = (string)verseData["verse"];
                    string text = (string)verseData["text"];

                    // Display the extracted information
                    RandomVerseLbl.Text = $"{bookname} {chapter}:{verse}\n{text}";
                }
                else
                {
                    RandomVerseLbl.Text = "No data found in the response.";
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
        //------------END BIBLE VERSE---------------
    }
    async void PrayerRequestsBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new PrayerPages.PrayerPage());
    }
    async void NewsFeedPageBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new NewsFeedPages.NewsFeedPage());
    }
    async void SettingsPageBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new SettingsPages.SettingsPage());
    }
    async void EventsPageBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new EventsPages.EventsPage());
    }
    async void MembersPageBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new MembersPages.MembersPage());
    }
    async void LiveFeedPageBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new LiveFeedPages.LiveFeedPage());
    }
    async void AdminPageBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new AdminPages.AdminPage());
    }
}


