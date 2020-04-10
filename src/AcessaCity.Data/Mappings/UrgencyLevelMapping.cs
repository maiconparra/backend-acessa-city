using System;
using AcessaCity.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcessaCity.Data.Mappings
{
    public class UrgencyLevelMapping : IEntityTypeConfiguration<UrgencyLevel>
    {
        public void Configure(EntityTypeBuilder<UrgencyLevel> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Description)
                .HasMaxLength(36)
                .IsRequired(true);

            builder.HasData(
                new UrgencyLevel()
                {
                    Id = Guid.Parse("553b0d79-20c1-49f3-8c2d-820128a293af"),
                    Description = "Sem muita urgência",
                    Priority = 5
                }
            );
        }
    }
}