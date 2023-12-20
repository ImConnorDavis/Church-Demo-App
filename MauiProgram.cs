using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;

namespace Church_Demo;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().UseMauiCommunityToolkitMediaElement().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            fonts.AddFont("Freedom-10eM.ttf", "FreedomFont");
            fonts.AddFont("Gold Lines Trial.otf", "GoldFont");
            fonts.AddFont("ArianaVioleta-dz2K.ttf", "ArianaFont");
        }).UseMauiCommunityToolkit();
        builder.ConfigureSyncfusionCore();
#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}