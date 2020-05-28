using System;
using AcessaCity.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcessaCity.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.FirstName)
                .HasMaxLength(45)
                .IsRequired(false);

            builder.Property(u => u.Email)
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(u => u.CreationDate)
                .IsRequired(true);           

            builder.Property(u => u.ProfileUrl)
                .IsRequired(false);

            builder.Property(u => u.Active)
                .HasDefaultValue(true);

            builder.HasData(
                new User() {
                    Id = Guid.Parse("8d4e6519-f440-4272-9c88-45d04f7f447e"),
                    CreationDate = DateTime.Parse("01-01-2020"),
                    Email = "acessa-city-admin@acessacity.com.br",
                    FirebaseUserId = "DDwoQufyCMSU0dE3QqhbvDFHIoa2",
                    FirstName = "Administrador AC"
                }
            );            
        }
        
    }
}