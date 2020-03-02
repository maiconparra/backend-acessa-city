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
        }
        
    }
}