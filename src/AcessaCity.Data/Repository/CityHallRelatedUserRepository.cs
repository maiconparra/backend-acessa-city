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
    }
}