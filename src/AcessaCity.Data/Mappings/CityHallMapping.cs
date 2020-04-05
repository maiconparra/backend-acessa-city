using AcessaCity.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcessaCity.Data.Mappings
{
    public class CityHallMapping : IEntityTypeConfiguration<CityHall>
    {
        public void Configure(EntityTypeBuilder<CityHall> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.CNPJ)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Property(c => c.Verified)
                .IsRequired()
                .HasColumnType("boolean")
                .HasDefaultValue(false);

            builder.Property(c => c.Address)
                .IsRequired(false)
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Number)
                .IsRequired(false)
                .HasColumnType("varchar(45)");

            builder.Property(c => c.Neighborhood)
                .IsRequired(false)
                .HasColumnType("varchar(120)");

            builder.Property(c => c.ZIPCode)
                .IsRequired(false)
                .HasColumnType("varchar(45)");                                         
        }
    }
}