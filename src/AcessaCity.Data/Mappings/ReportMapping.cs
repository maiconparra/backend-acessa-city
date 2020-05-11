using AcessaCity.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcessaCity.Data.Mappings
{
    public class ReportMapping : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Title)
                .HasMaxLength(200)
                .IsRequired(true);

            builder.Property(r => r.Street)
                .HasMaxLength(250)
                .IsRequired(false);

            builder.Property(r => r.Neighborhood)
                .HasMaxLength(250)
                .IsRequired(false);
            
            builder.Property(r => r.Latitude)
                .HasColumnType("decimal(10,8)")
                .IsRequired(true)
                .HasDefaultValue(0.0);

            builder.Property(r => r.Longitude)
                .HasColumnType("decimal(10,8)")
                .IsRequired(true)
                .HasDefaultValue(0.0);

            builder.Property(r => r.Accuracy)
                .HasColumnType("decimal(10,8)")
                .IsRequired(true)
                .HasDefaultValue(0.0);                          
        }
    }
}