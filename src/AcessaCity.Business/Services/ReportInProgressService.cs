using System;
using System.Threading.Tasks;
using AcessaCity.Business.Interfaces;
using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Interfaces.Service;
using AcessaCity.Business.Models;

namespace AcessaCity.Business.Services
{
    public class ReportInProgressService : ServiceBase, IReportInProgressService
    {
        private readonly IReportInProgressRepository _repository;
        public ReportInProgressService(
            INotifier notifier,
            IReportInProgressRepository repository
            ) : base(notifier)
        {
            _repository = repository;
        }

        public async Task Add(ReportInProgress report)
        {
            await _repository.Add(report);
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

        public async Task<ReportInProgress> GetById(Guid id)
        {
            return await _repository.GetById(id);
        }

        public Task Remove(ReportInProgress report)
        {
            throw new NotImplementedException();
        }

        public Task Update(ReportInProgress report)
        {
            throw new NotImplementedException();
        }
    }
}