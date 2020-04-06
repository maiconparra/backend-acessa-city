using System;
using System.Threading.Tasks;
using AcessaCity.Business.Models;

namespace AcessaCity.Business.Interfaces.Repository
{
    public interface IReportClassificationRepository : IRepository<ReportClassification>
    {
        Task<ReportClassification> FindUserClassification(Guid userId, Guid ReportId);
    }
}