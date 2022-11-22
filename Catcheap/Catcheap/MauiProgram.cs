using Catcheap.Models.Calculator_Classes;
using Catcheap.Models.ChargingStations_Classes;
using Catcheap.Models.FileIO_Classes;
using Catcheap.Models.Journeys_Classes;
using Catcheap.Models.Price_Classes;
using Catcheap.Models.ToStringConverter_Classes;
using Catcheap.Models.Validation_Classes;
using Catcheap.Models.Vehicles_Classes;
using Catcheap.Models.Vehicles_Classes.Cars_Classes;
using Catcheap.Models.Vehicles_Classes.Other_Classes;
using Catcheap.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Catcheap.ViewModel;
using Plugin.LocalNotification;
using Catcheap.Models.Notification_Classes;
using Catcheap.Client;

namespace Catcheap;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseLocalNotification()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddTransient<AppShell>();
        builder = RegisterViews(builder);
        builder.Services.AddTransient<AddJourneyPageViewModel>();
        builder.Services.AddTransient<JourneyField>();
        builder = RegisterModels(builder);
        builder.Services.AddSingleton<Charges>();
        builder.Services.AddSingleton<ChargeViewModel>();

        return builder.Build();
    }

    public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<AddCar>();
        mauiAppBuilder.Services.AddTransient<AddElectricScooter>();
        mauiAppBuilder.Services.AddTransient<AddJourneyPage>();
        mauiAppBuilder.Services.AddTransient<ChargingStations>();
        mauiAppBuilder.Services.AddTransient<DashboardPage>();
        mauiAppBuilder.Services.AddTransient<DisplayVehiclePage>();
        mauiAppBuilder.Services.AddTransient<JourneyCalculator>();
        mauiAppBuilder.Services.AddTransient<MyJourneysPage>();
        mauiAppBuilder.Services.AddTransient<PricePage>();
        mauiAppBuilder.Services.AddTransient<StatsPage>();
        mauiAppBuilder.Services.AddTransient<TrendsPage>();

        ApiClient.Init();

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<Car>();
        mauiAppBuilder.Services.AddSingleton<CarLoaderSaver>();
        mauiAppBuilder.Services.AddSingleton<ScooterLoaderSaver>();
        mauiAppBuilder.Services.AddTransient<VehicleScooter>();
        mauiAppBuilder.Services.AddTransient<List<Vehicle>>();
        mauiAppBuilder.Services.AddTransient<Calculator>();
        mauiAppBuilder.Services.AddTransient<FileIO>();
        mauiAppBuilder.Services.AddTransient<List<Journey>>();
        mauiAppBuilder.Services.AddTransient<Journeys>();
        mauiAppBuilder.Services.AddTransient<Lazy<Journeys>>();
        mauiAppBuilder.Services.AddTransient<Vehicle>();
        mauiAppBuilder.Services.AddTransient<JourneysLoaderSaver>();
        mauiAppBuilder.Services.AddTransient<Price>();
        mauiAppBuilder.Services.AddTransient<List<DayPrice>>();
        mauiAppBuilder.Services.AddTransient<PriceReader>();
        mauiAppBuilder.Services.AddSingleton<CarString>();
        mauiAppBuilder.Services.AddSingleton<ElectricScooterString>();
        mauiAppBuilder.Services.AddTransient<ValidateInput<string>>();
        mauiAppBuilder.Services.AddTransient<PushNotification>();

        return mauiAppBuilder;
    }
}
