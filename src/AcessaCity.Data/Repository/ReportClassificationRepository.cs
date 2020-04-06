using System;
using System.Linq;
using System.Threading.Tasks;
using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Models;
using AcessaCity.Data.Context;

namespace AcessaCity.Data.Repository
{
    public class ReportClassificationRepository : Repository<ReportClassification>, IReportClassificationRepository
    {
        public ReportClassificationRepository(AppDbContext db) : base(db)
        {
        }

        public async Task<ReportClassification> FindUserClassification(Guid userId, Guid ReportId)
        {
            var classification = await DbSet
                .Where(c => c.UserId == userId && c.ReportId == ReportId)
                .ToAsyncEnumerable().FirstOrDefault();

            return classification;
        }
    }
}