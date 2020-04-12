using System;
using AcessaCity.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcessaCity.Data.Mappings
{
    public class RoleMapping : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);

            builder.HasData(
                new Role()
                {
                    Id = Guid.Parse("a134413f-fed2-411d-a157-215a0a5eff03"),
                    Name = "user"
                },
                new Role()
                {
                    Id = Guid.Parse("859eca17-0122-489b-8528-9e873ac56f74"),
                    Name = "moderator"
                },
                new Role()
                {
                    Id = Guid.Parse("f5e0afe9-f2e1-473c-99bc-01aa12c196ce"),
                    Name = "coordinator"
                },
                new Role()
                {
                    Id = Guid.Parse("a22497ac-2331-4172-af66-b40fa16e637c"),
                    Name = "admin"
                }
            );
        }
    }
}