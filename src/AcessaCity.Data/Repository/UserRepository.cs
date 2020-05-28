using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Models;
using AcessaCity.Data.Context;

namespace AcessaCity.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext db) : base(db)
        {
        }

        public async Task Inactive(Guid userId)
        {
            var user = await GetById(userId);
            user.Active = false;

            await Update(user);
        }

        public async Task<IEnumerable<User>> UserCoordinators(Guid userId)
        {
            Guid coord = Guid.Parse("f5e0afe9-f2e1-473c-99bc-01aa12c196ce");
            User reqUser = await GetById(userId);
            var userRoles = Db.Set<UserRoles>();

            var users =
            from user in DbSet
                where user.CityHallId == reqUser.CityHallId
                && user.Id != userId
                && user.Active == true
                join role in userRoles on true equals role.Role.Name == "coordinator"
            select(role.User);

            return users;
        }
    }
}