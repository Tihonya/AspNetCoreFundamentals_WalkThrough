using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Models;

namespace OdeToFood.DataLayer
{
    public class OdeToFoodDbContext : DbContext
    {
        public OdeToFoodDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Restaurant> Restaurants { get; set; }

    }
}
