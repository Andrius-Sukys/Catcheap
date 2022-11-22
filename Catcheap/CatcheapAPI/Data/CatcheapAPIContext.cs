using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CatcheapAPI.Models.Vehicles_Classes.Cars_Classes;
using CatcheapAPI.Models.Journeys_Classes;

namespace CatcheapAPI.Data
{
    public class CatcheapAPIContext : DbContext
    {
        public CatcheapAPIContext (DbContextOptions<CatcheapAPIContext> options)
            : base(options)
        {
        }

        public DbSet<CatcheapAPI.Models.Vehicles_Classes.Cars_Classes.Car> Car { get; set; } = default!;

        public DbSet<CatcheapAPI.Models.Journeys_Classes.Journeys> Journeys { get; set; }

        public DbSet<CatcheapAPI.Models.Journeys_Classes.Journey> Journey { get; set; }
    }
}
