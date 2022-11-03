using Catcheap.Models.Vehicles_Classes.Cars_Classes;
using Catcheap.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Catcheap;

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

        builder.Services.AddTransient<AppShell>();
        builder = RegisterViews(builder);
        builder.Services.AddTransient<AddJourneyPageViewModel>();
        builder.Services.AddTransient<JourneyField>();
        builder.Services.AddTransient<Car>();

        return builder.Build();
    }

    public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<AddCar>();
        mauiAppBuilder.Services.AddTransient<AddChargePage>();
        mauiAppBuilder.Services.AddTransient<AddElectricScooter>();
        mauiAppBuilder.Services.AddTransient<AddJourneyPage>();
        mauiAppBuilder.Services.AddTransient<Charges>();
        mauiAppBuilder.Services.AddTransient<ChargingStations>();
        mauiAppBuilder.Services.AddTransient<DashboardPage>();
        mauiAppBuilder.Services.AddTransient<DisplayVehiclePage>();
        mauiAppBuilder.Services.AddTransient<JourneyCalculator>();
        mauiAppBuilder.Services.AddTransient<MyJourneysPage>();
        mauiAppBuilder.Services.AddTransient<PricePage>();
        mauiAppBuilder.Services.AddTransient<StatsPage>();
        mauiAppBuilder.Services.AddTransient<TrendsPage>();

        return mauiAppBuilder;
    }
}
