using System;
using System.Threading.Tasks;
using AcessaCity.Business.Models;

namespace AcessaCity.Business.Interfaces.Service
{
    public interface IReportInProgressService : IDisposable
    {
        Task Add(ReportInProgress report);
        Task Update(ReportInProgress report);
        Task Remove(ReportInProgress report);
        
        Task<ReportInProgress> GetById(Guid id);
    }
}