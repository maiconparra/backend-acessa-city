using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Models;
using AcessaCity.Data.Context;

namespace AcessaCity.Data.Repository
{
    public class ReportCommentaryRepository : Repository<ReportCommentary>, IReportCommentaryRepository
    {
        public ReportCommentaryRepository(AppDbContext db) : base(db)
        {
        }
    }
}