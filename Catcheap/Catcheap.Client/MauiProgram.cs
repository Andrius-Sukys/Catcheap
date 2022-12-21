using Catcheap.Client.ViewModels;
using Catcheap.Client.Views;
using Catcheap.Client.Models;
using Catcheap.Client.HttpServices;

namespace Catcheap.Client
{
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

            builder.Services.AddTransient<CarView>();
            builder.Services.AddSingleton<HttpService<Car>>();
            builder.Services.AddTransient<CarViewModel>();
            builder.Services.AddTransient<AddCarView>();
            builder.Services.AddTransient<AddCarViewModel>();
            //builder.Services.AddTransient<AddCarChargeViewModel>();
            //builder.Services.AddTransient<AddChargeView>();

            Routing.RegisterRoute("addcar", typeof(AddCarView));
            Routing.RegisterRoute("car", typeof(CarView));

            return builder.Build();
        }
    }
}