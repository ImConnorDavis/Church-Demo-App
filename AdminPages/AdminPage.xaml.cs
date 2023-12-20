using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace Church_Demo.AdminPages;

public partial class AdminPage : ContentPage
{
	public AdminPage()
	{
		InitializeComponent();
        On<iOS>().SetUseSafeArea(false);
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        PostNewsSelectionPageBtn.BackgroundColor = Color.FromArgb(MainPage.ButtonColor);
        PostEventPageBtn.BackgroundColor = Color.FromArgb(MainPage.ButtonColor);
    }
    async void PostNewsSelectionPageBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new AdminPages.PostNewsSelection());
    }
    async void PostEventPageBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new AdminPages.CreateEventPage());
    }
}
