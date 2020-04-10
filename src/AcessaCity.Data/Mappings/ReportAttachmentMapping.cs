using AcessaCity.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcessaCity.Data.Mappings
{
    public class ReportAttachmentMapping : IEntityTypeConfiguration<ReportAttachment>
    {
        public void Configure(EntityTypeBuilder<ReportAttachment> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.MediaType)
                .HasMaxLength(45)
                .IsRequired(true);
        }
    }
}