using AcessaCity.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcessaCity.Data.Mappings
{
    public class InteractionHistoryMapping : IEntityTypeConfiguration<InteractionHistory>
    {
        public void Configure(EntityTypeBuilder<InteractionHistory> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.oldReportStatusId)
                .IsRequired(false);
        }
    }
}