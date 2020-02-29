using System.Linq;
using AcessaCity.Business.Models;
using AcessaCity.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace AcessaCity.Data.Context
{
    public class AppDbContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CityHall> CityHalls { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new StateMapping());
            modelBuilder.ApplyConfiguration(new CityMapping());

            base.OnModelCreating(modelBuilder);
        }        
    }
}