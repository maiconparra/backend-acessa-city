using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Models;
using AcessaCity.Data.Context;

namespace AcessaCity.Data.Repository
{
    public class CityHallRelatedUserRepository : Repository<CityHallRelatedUser>, ICityHallRelatedUserRepository
    {
        public CityHallRelatedUserRepository(AppDbContext db) : base(db)
        {
        }

        public async Task<IEnumerable<User>> AllRelatedUsers(Guid cityhallId)
        {            
            var list = await Find(x => x.CityHallId == cityhallId);            
            return list.Select(u => u.User);            
        }
    }
}