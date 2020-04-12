using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Models;
using AcessaCity.Data.Context;

namespace AcessaCity.Data.Repository
{
    public class ReportInteractionHistoryRepository : Repository<InteractionHistory>, IReportInteractionHistoryRepository
    {
        public ReportInteractionHistoryRepository(AppDbContext db) : base(db)
        {
        }
    }
}