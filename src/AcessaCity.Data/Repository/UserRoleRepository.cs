using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Models;
using AcessaCity.Data.Context;

namespace AcessaCity.Data.Repository
{
    public class UserRoleRepository : Repository<UserRoles>, IUserRoleRepository
    {
        public UserRoleRepository(AppDbContext db) : base(db)
        {
        }
    }
}