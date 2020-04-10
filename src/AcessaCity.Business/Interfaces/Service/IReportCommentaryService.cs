using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AcessaCity.Business.Models;

namespace AcessaCity.Business.Interfaces.Service
{
    public interface IReportCommentaryService : IDisposable
    {
        Task Add(ReportCommentary commentary);
        Task Update(ReportCommentary commentary);
        Task Remove(ReportCommentary commentary);
        Task<ReportCommentary> GetById(Guid id);

        Task<IEnumerable<ReportCommentary>> GetCommentsByReportId(Guid ReportId);
    }
}