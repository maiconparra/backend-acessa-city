using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Models;
using AcessaCity.Data.Context;

namespace AcessaCity.Data.Repository
{
    public class ReportAttachmentRepository : Repository<ReportAttachment>, IReportAttachmentRepository
    {
        public ReportAttachmentRepository(AppDbContext db) : base(db)
        {
        }
    }
}