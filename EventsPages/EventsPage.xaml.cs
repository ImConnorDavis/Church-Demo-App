using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace Church_Demo.EventsPages;

public partial class EventsPage : ContentPage
{
	public EventsPage()
	{
		InitializeComponent();
        On<iOS>().SetUseSafeArea(false);
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Assuming that Prayers is the ObservableCollection or List that you're binding to
        // You should refresh your Prayers collection here
        BindingContext = new EventControl();
    }
    async void EventSelected(object sender, ItemTappedEventArgs e)
    {
        var mySelectedItem = e.Item as Event;
        await Navigation.PushAsync(new ViewEventPage(mySelectedItem.EventName, mySelectedItem.EventDetails, mySelectedItem.EventDate, mySelectedItem.EventTime));
    }
}
