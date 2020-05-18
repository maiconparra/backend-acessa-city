using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Models;
using AcessaCity.Data.Context;

namespace AcessaCity.Data.Repository
{
    public class ReportInteractionHistoryCommentaryRepository : Repository<InteractionHistoryCommentary>, IReportInteractionHistoryCommentaryRepository
    {
        public ReportInteractionHistoryCommentaryRepository(AppDbContext db) : base(db)
        {
        }
    }
}