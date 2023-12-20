using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace Church_Demo.PrayerPages;

public partial class ViewPrayerPage : ContentPage
{
	public ViewPrayerPage(string Name, string PrayerContents, string PostedName)
	{
		InitializeComponent();
        On<iOS>().SetUseSafeArea(false);
        NameLbl.Text = Name;
		PrayerContentsLbl.Text = PrayerContents;
        PrayerNameFrame.BackgroundColor = Color.FromArgb(MainPage.ButtonColor);
        PrayerContentsFrame.BackgroundColor = Color.FromArgb(MainPage.ButtonColor);
    }
}
