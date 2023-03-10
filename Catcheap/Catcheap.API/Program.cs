using Catcheap.API.Data;
using Catcheap.API.Repositories.CarRepo;
using Catcheap.API.Repositories.MiscRepo;
using Catcheap.API.Repositories.ScooterRepo;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using Autofac;
using Serilog;
using Catcheap.API.Helper;
using Autofac.Extras.DynamicProxy;
using Autofac.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using Catcheap.API.Services.CarServices;
using Catcheap.API.Services.MiscServices;
using Catcheap.API.Services.ScooterServices;
using Catcheap.API.Interfaces.IRepository.ICarRepo;
using Catcheap.API.Interfaces.IRepository.IMiscRepo;
using Catcheap.API.Interfaces.IRepository.IScooterRepo;
using Catcheap.API.Interfaces.IService.ICarServices;
using Catcheap.API.Interfaces.IService.IMiscServices;
using Catcheap.API.Interfaces.IService.IScooterServices;

var builder = WebApplication.CreateBuilder(args);

ILifetimeScope AutofacContainer;

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

Log.Logger = new LoggerConfiguration()
                .WriteTo.File("Logs\\log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(MappingProfiles));

builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarJourneyRepository, CarJourneyRepository>();
builder.Services.AddScoped<ICarChargeRepository, CarChargeRepository>();

builder.Services.AddScoped<IScooterRepository, ScooterRepository>();
builder.Services.AddScoped<IScooterJourneyRepository, ScooterJourneyRepository>();
builder.Services.AddScoped<IScooterChargeRepository, ScooterChargeRepository>();

builder.Services.AddScoped<IChargingStationRepository, ChargingStationRepository>();
builder.Services.AddScoped<INordpoolPriceRepository, NordpoolPriceRepository>();


builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ICarChargeService, CarChargeService>();
builder.Services.AddScoped<ICarStatsService, CarStatsService>();

builder.Services.AddScoped<IScooterService, ScooterService>();
builder.Services.AddScoped<IScooterChargeService, ScooterChargeService>();
builder.Services.AddScoped<IScooterStatsService, ScooterStatsService>();

builder.Services.AddScoped<IChargingStationsService, ChargingStationsService>();
builder.Services.AddScoped<INordpoolPriceService, NordpoolPriceService>();

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterType<CarRepository>().As<ICarRepository>()
        .EnableInterfaceInterceptors().InterceptedBy(typeof(LogAspect))
        .InstancePerDependency();

    builder.RegisterType<CarChargeRepository>().As<ICarChargeRepository>()
        .EnableInterfaceInterceptors().InterceptedBy(typeof(LogAspect))
        .InstancePerDependency();

    builder.RegisterType<CarJourneyRepository>().As<ICarJourneyRepository>()
        .EnableInterfaceInterceptors().InterceptedBy(typeof(LogAspect))
        .InstancePerDependency();

    builder.RegisterType<ScooterRepository>().As<IScooterRepository>()
        .EnableInterfaceInterceptors().InterceptedBy(typeof(LogAspect))
        .InstancePerDependency();

    builder.RegisterType<ScooterChargeRepository>().As<IScooterChargeRepository>()
        .EnableInterfaceInterceptors().InterceptedBy(typeof(LogAspect))
        .InstancePerDependency();

    builder.RegisterType<ScooterJourneyRepository>().As<IScooterJourneyRepository>()
        .EnableInterfaceInterceptors().InterceptedBy(typeof(LogAspect))
        .InstancePerDependency();

    builder.RegisterType<ChargingStationRepository>().As<IChargingStationRepository>()
        .EnableInterfaceInterceptors().InterceptedBy(typeof(LogAspect))
        .InstancePerDependency();

    builder.RegisterType<NordpoolPriceRepository>().As<INordpoolPriceRepository>()
        .EnableInterfaceInterceptors().InterceptedBy(typeof(LogAspect))
        .InstancePerDependency();


    builder.RegisterType<CarService>().As<ICarService>()
        .EnableInterfaceInterceptors().InterceptedBy(typeof(LogAspect))
        .InstancePerDependency();

    builder.RegisterType<CarChargeService>().As<ICarChargeService>()
        .EnableInterfaceInterceptors().InterceptedBy(typeof(LogAspect))
        .InstancePerDependency();

    builder.RegisterType<CarStatsService>().As<ICarStatsService>()
        .EnableInterfaceInterceptors().InterceptedBy(typeof(LogAspect))
        .InstancePerDependency();

    builder.RegisterType<ScooterService>().As<IScooterService>()
        .EnableInterfaceInterceptors().InterceptedBy(typeof(LogAspect))
        .InstancePerDependency();

    builder.RegisterType<ScooterChargeService>().As<IScooterChargeService>()
        .EnableInterfaceInterceptors().InterceptedBy(typeof(LogAspect))
        .InstancePerDependency();

    builder.RegisterType<ScooterStatsService>().As<IScooterStatsService>()
        .EnableInterfaceInterceptors().InterceptedBy(typeof(LogAspect))
        .InstancePerDependency();

    builder.RegisterType<ChargingStationsService>().As<IChargingStationsService>()
        .EnableInterfaceInterceptors().InterceptedBy(typeof(LogAspect))
        .InstancePerDependency();

    builder.RegisterType<NordpoolPriceService>().As<INordpoolPriceService>()
        .EnableInterfaceInterceptors().InterceptedBy(typeof(LogAspect))
        .InstancePerDependency();

    builder.Register(x => Log.Logger).SingleInstance();
    builder.RegisterType<LogAspect>().SingleInstance();
});

builder.Services.AddHttpClient();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

AutofacContainer = app.Services.GetAutofacRoot();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
