using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Models;
using AcessaCity.Data.Context;

namespace AcessaCity.Data.Repository
{
    public class ReportStatusRepository : Repository<ReportStatus>, IReportStatusRepository
    {
        public ReportStatusRepository(AppDbContext db) : base(db)
        {
        }
    }
}