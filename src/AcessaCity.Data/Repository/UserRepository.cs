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

        public async Task<IEnumerable<User>> UserCoordinators(Guid userId)
        {
            var cityHallRelatedUserDbSet = Db.Set<CityHallRelatedUser>();
            var user = await this.GetById(userId);
            Console.WriteLine(user.RelatedCityHalls.Count());

            var lista =
            from ch in cityHallRelatedUserDbSet
            where user.RelatedCityHalls
                .Select(r => r.CityHallId) 
                .Contains(ch.CityHallId)                
            select (ch.User); 

            return lista.Where(l => l.Id != userId);
        }
    }
}