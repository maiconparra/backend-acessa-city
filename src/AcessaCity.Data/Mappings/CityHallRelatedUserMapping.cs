using AcessaCity.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcessaCity.Data.Mappings
{
    public class CityHallRelatedUserMapping : IEntityTypeConfiguration<CityHallRelatedUser>
    {
        public void Configure(EntityTypeBuilder<CityHallRelatedUser> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.User)
                .WithMany(u => u.RelatedCityHalls)
                .HasForeignKey(c => c.UserId);

            builder.HasOne(c => c.CityHall)
                .WithMany(h => h.RelatedUsers)
                .HasForeignKey(c => c.CityHallId);
        }
    }
}