using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace Church_Demo.EventsPages;

public partial class ViewEventPage : ContentPage
{
	public ViewEventPage(string EventName, string EventDetails, string EventDate, string EventTime)
	{
		InitializeComponent();
        On<iOS>().SetUseSafeArea(false);
        EventNameLbl.Text = EventName;
		EventDetailsLbl.Text = EventDetails;
		EventDateLbl.Text = EventDate;
		EventTimeLbl.Text = EventTime;
		EventNameFrame.BackgroundColor = Color.FromArgb(MainPage.ButtonColor);
		EventDetailsFrame.BackgroundColor = Color.FromArgb(MainPage.ButtonColor);
		EventDateFrame.BackgroundColor = Color.FromArgb(MainPage.ButtonColor);
    }
}
