namespace Church_Demo;

public partial class App : Application
{
	public App()
	{
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjY2NDk1NUAzMjMyMmUzMDJlMzBDOVlORmlQMnd0dXJvZFdqK2Q3RDZNLzB3NWFjd0hqV3VnU29rTXpvNC9zPQ==");
        InitializeComponent();
        //MainPage = new AppShell();
        MainPage = new NavigationPage(new MainPage());
    }
}

