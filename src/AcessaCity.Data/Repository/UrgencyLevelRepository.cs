using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Models;
using AcessaCity.Data.Context;

namespace AcessaCity.Data.Repository
{
    public class UrgencyLevelRepository : Repository<UrgencyLevel>, IUrgencyLevelRepository
    {
        public UrgencyLevelRepository(AppDbContext db) : base(db)
        {
        }
    }
}