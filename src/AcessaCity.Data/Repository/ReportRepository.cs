using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Models;
using AcessaCity.Data.Context;

namespace AcessaCity.Data.Repository
{
    public class ReportRepository : Repository<Report>, IReportRepository
    {
        public ReportRepository(AppDbContext db) : base(db)
        {
        }
    }
}