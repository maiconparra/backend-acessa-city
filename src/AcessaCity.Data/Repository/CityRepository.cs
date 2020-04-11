using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Models;
using AcessaCity.Data.Context;

namespace AcessaCity.Data.Repository
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(AppDbContext db) : base(db)
        {
        }
    }
}