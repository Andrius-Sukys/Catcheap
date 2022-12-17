using Catcheap_API.Models.CarModels;
using Catcheap_API.Models.MiscModels;
using Catcheap_API.Models.ScooterModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Serilog;

namespace Catcheap_API.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    public DbSet<Car> Cars { get; set; }

    public DbSet<CarCharge> CarCharges { get; set; }

    public DbSet<CarJourney> CarJourneys { get; set; }

    public DbSet<ChargingStation> ChargingStations { get; set; }

    public DbSet<NordpoolPrice> NordpoolPrices { get; set; }

    public DbSet<Scooter> Scooters { get; set; }

    public DbSet<ScooterCharge> ScooterCharges { get; set; }

    public DbSet<ScooterJourney> ScooterJourneys { get; set; }
}
