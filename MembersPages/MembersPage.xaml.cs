using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace Church_Demo.MembersPages;

public partial class MembersPage : ContentPage
{
	public MembersPage()
	{
		InitializeComponent();
        On<iOS>().SetUseSafeArea(false);
    }
}
