using System;
using System.Linq;
using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcessaCity.Data.Mappings
{
    public class CityMapping : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(45);

            builder.Property(c => c.Latitude)
                .HasColumnType("decimal(11, 8)");

            builder.Property(c => c.Longitude)
                .HasColumnType("decimal(11, 8)");     

            builder.HasOne(c => c.CityState)
                .WithMany(s => s.Cities)
                .IsRequired();   

            builder.HasData
            (
                new City
                {
                    Id = Guid.NewGuid(),
                    Name = "Campinas",
                    IBGECode = 3509502,
                    StateId = Guid.Parse("b545ceb9-fbde-43c9-bbcc-de62a49e1661"),
                    Latitude = -22.8920565,
                    Longitude = -47.2079794
                }
            );            
        }
    }
}