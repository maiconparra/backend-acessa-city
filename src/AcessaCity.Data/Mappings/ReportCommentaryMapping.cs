using AcessaCity.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcessaCity.Data.Mappings
{
    public class ReportCommentaryMapping : IEntityTypeConfiguration<ReportCommentary>
    {
        public void Configure(EntityTypeBuilder<ReportCommentary> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.User);
            builder.HasOne(c => c.Report);

            builder.Property(c => c.UserId)
                .IsRequired(true);

            builder.Property(c => c.ReportId)
                .IsRequired(true);                
        }
    }
}