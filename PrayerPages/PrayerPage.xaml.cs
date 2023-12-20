using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace Church_Demo.PrayerPages;

public partial class PrayerPage : ContentPage
{
	public PrayerPage()
	{
		InitializeComponent();
        On<iOS>().SetUseSafeArea(false);
        //BindingContext = new PrayerControl();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Assuming that Prayers is the ObservableCollection or List that you're binding to
        // You should refresh your Prayers collection here
        BindingContext = new PrayerControl();
    }
    async void NewPrayerBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NewPrayerPage());
    }
    async void PrayerSelected(object sender, ItemTappedEventArgs e)
    {
        var mySelectedItem = e.Item as Prayer;
        await Navigation.PushAsync(new ViewPrayerPage(mySelectedItem.Name, mySelectedItem.PrayerContents, mySelectedItem.PostedName));
    }
}
