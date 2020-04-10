using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AcessaCity.Business.Interfaces;
using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Interfaces.Service;
using AcessaCity.Business.Models;
using AcessaCity.Business.Models.Validations;

namespace AcessaCity.Business.Services
{
    public class ReportCommentaryService : ServiceBase, IReportCommentaryService
    {
        private readonly IReportCommentaryRepository _repository;
        
        public ReportCommentaryService(INotifier notifier, IReportCommentaryRepository repository) : base(notifier)
        {
            _repository = repository;
        }

        public async Task Add(ReportCommentary commentary)
        {
            if (!ExecuteValidation(new ReportCommentaryValidation(), commentary)) return;

            commentary.CreationDate = DateTime.Now;
            commentary.Approved = true;

            await _repository.Add(commentary);
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

        public async Task<ReportCommentary> GetById(Guid id)
        {
            return await _repository.GetById(id);
        }

        public Task<IEnumerable<ReportCommentary>> GetCommentsByReportId(Guid ReportId)
        {
            throw new NotImplementedException();
        }

        public Task Remove(ReportCommentary commentary)
        {
            throw new NotImplementedException();
        }

        public Task Update(ReportCommentary commentary)
        {
            throw new NotImplementedException();
        }
    }
}