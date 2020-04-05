using System;
using AcessaCity.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcessaCity.Data.Mappings
{
    public class ReportStatusMapping : IEntityTypeConfiguration<ReportStatus>
    {
        public void Configure(EntityTypeBuilder<ReportStatus> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Description)
                .HasMaxLength(36)
                .IsRequired(true);

            builder.Property(r => r.Approved)
                .HasDefaultValue(false);

            builder.Property(r => r.Denied)
                .HasDefaultValue(false);

            builder.Property(r => r.InProgress)
                .HasDefaultValue(false);

            builder.Property(r => r.Review)
                .HasDefaultValue(false);

            builder.HasData
            (
                new ReportStatus()
                {
                    Id = Guid.Parse("96afa0df-8ad9-4a44-a726-70582b7bd010"),
                    Description = "Aprovado",
                    Approved = true
                },
                new ReportStatus()
                {
                    Id = Guid.Parse("52ccae2e-af86-4fcc-82ea-9234088dbedf"),
                    Description = "Negado",
                    Denied = true
                },
                new ReportStatus()
                {
                    Id = Guid.Parse("c37d9588-1875-44dd-8cf1-6781de7533c3"),
                    Description = "Em progresso",
                    InProgress = true
                },
                new ReportStatus()
                {
                    Id = Guid.Parse("48cf5f0f-40c9-4a79-9627-6fd22018f72c"),
                    Description = "Em análise",
                    Review = true
                }                                              
            );
        }
    }
}