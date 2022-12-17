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

        public DbSet<Car> Car { get; set; } = default!;

        public DbSet<Journeys> Journeys { get; set; }

        public DbSet<Journey> Journey { get; set; }
    }
}
