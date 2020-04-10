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
        public DbSet<User> Users { get; set; }
        public DbSet<CityHallRelatedUser> CityHallRelatedUser { get; set; }
        public DbSet<ReportStatus> ReportStatus { get; set; }
        public DbSet<ReportClassification> ReportClassifications { get; set; }
        public DbSet<UrgencyLevel> UrgencyLevels { get; set; }
        public DbSet<ReportCommentary> ReportComments { get; set; }
        public DbSet<ReportAttachment> ReportAttachments { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder
            //     .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.DetachedLazyLoadingWarning));
        }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new StateMapping());
            modelBuilder.ApplyConfiguration(new CityMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new CityHallMapping());
            modelBuilder.ApplyConfiguration(new CityHallRelatedUserMapping());
            modelBuilder.ApplyConfiguration(new ReportStatusMapping());
            modelBuilder.ApplyConfiguration(new UrgencyLevelMapping());
            modelBuilder.ApplyConfiguration(new ReportMapping());
            modelBuilder.ApplyConfiguration(new ReportCommentaryMapping());
            modelBuilder.ApplyConfiguration(new ReportAttachmentMapping());

            base.OnModelCreating(modelBuilder);
        }        
    }
}