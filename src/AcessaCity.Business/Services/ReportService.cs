using System.Threading.Tasks;
using AcessaCity.Business.Interfaces;
using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Interfaces.Service;
using AcessaCity.Business.Models;
using AcessaCity.Business.Models.Validations;

namespace AcessaCity.Business.Services
{
    public class ReportService : ServiceBase, IReportService
    {
        private readonly IReportRepository _repository;
        
        public ReportService(
            INotifier notifier,
            IReportRepository repository) : base(notifier)
        {
            _repository = repository;
        }

        public async Task Add(Report report)
        {
            if (!ExecuteValidation(new ReportValidation(), report)) return;

            await _repository.Add(report);
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

        public Task Remove(Report id)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Report report)
        {
            throw new System.NotImplementedException();
        }
    }
}