using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcessaCity.Business.Interfaces;
using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Interfaces.Service;
using AcessaCity.Business.Models;

namespace AcessaCity.Business.Services
{
    public class ReportInteractionHistoryService : ServiceBase, IReportInteractionHistoryService
    {
        private readonly IReportInteractionHistoryRepository _repository;
        public ReportInteractionHistoryService(
            INotifier notifier,
            IReportInteractionHistoryRepository repository
            ) : base(notifier)
        {
            _repository = repository;
        }
        
        public Task Add(InteractionHistory interaction)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

        public async Task<IEnumerable<InteractionHistory>> InteractionsByReportId(Guid reportId)
        {
            var interactions = await _repository.Find(i => i.ReportId == reportId);
            return interactions.OrderBy(x => x.CreationDate);
        }
    }
}