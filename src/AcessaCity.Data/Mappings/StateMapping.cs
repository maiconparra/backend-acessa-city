using System;
using AcessaCity.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcessaCity.Data.Mappings
{
    public class StateMapping : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(45);

            builder.Property(s => s.UFCode)
                .IsRequired()
                .HasMaxLength(2);

            builder.HasMany(s => s.Cities)
                .WithOne(c => c.CityState);

            builder.HasData
            (
                new State
                {
                    Id = Guid.Parse("b545ceb9-fbde-43c9-bbcc-de62a49e1661"),
                    UFCode = "SP",
                    Name = "São Paulo"
                },

                new State
                {
                    Id = Guid.Parse("2f0892c5-f505-4bbf-a363-52f9a6754259"),
                    UFCode = "MG",
                    Name = "Minas Gerais"
                }                                
            );
        }
    }
}