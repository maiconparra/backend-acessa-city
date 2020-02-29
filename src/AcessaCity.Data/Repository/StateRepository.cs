using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Models;
using AcessaCity.Data.Context;

namespace AcessaCity.Data.Repository
{
    public class StateRepository : Repository<State>, IStateRepository
    {
        public StateRepository(AppDbContext db) : base(db)
        {
        }
    }
}