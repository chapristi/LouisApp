using Microsoft.Extensions.Logging;
using LouisApp.ViewModels;
using LouisApp.Views;

namespace LouisApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Enregistrez vos services ici
        builder.Services.AddSingleton<CountryViewModel>();
        builder.Services.AddTransient<AddCountryPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}