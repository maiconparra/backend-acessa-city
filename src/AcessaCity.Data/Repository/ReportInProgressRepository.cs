using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Models;
using AcessaCity.Data.Context;

namespace AcessaCity.Data.Repository
{
    public class ReportInProgressRepository : Repository<ReportInProgress>, IReportInProgressRepository
    {
        public ReportInProgressRepository(AppDbContext db) : base(db)
        {
        }
    }
}