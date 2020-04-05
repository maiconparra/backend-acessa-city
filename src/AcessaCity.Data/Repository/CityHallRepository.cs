using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Models;
using AcessaCity.Data.Context;

namespace AcessaCity.Data.Repository
{
    public class CityHallRepository : Repository<CityHall>, ICityHallRepository
    {
        public CityHallRepository(AppDbContext db) : base(db)
        {
        }
    }
}