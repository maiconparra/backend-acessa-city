using System;
using AcessaCity.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcessaCity.Data.Mappings
{
    public class UserRolesMapping : IEntityTypeConfiguration<UserRoles>
    {
        public void Configure(EntityTypeBuilder<UserRoles> builder)
        {
            builder.HasData(
                new UserRoles() {
                    Id = Guid.Parse("1f548d02-cdac-4c00-b2b7-9c088e0f7c81"),
                    RoleId = Guid.Parse("a22497ac-2331-4172-af66-b40fa16e637c"),
                    UserId = Guid.Parse("da6712f8-405c-4ee7-b1d6-15295fa93efe")
                }
            );   
        }
    }
}