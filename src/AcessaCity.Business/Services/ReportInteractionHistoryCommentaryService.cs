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
    public class ReportInteractionHistoryCommentaryService : ServiceBase, IReportInteractionHistoryCommentaryService
    {
        private readonly IReportInteractionHistoryCommentaryRepository _repository;

        public ReportInteractionHistoryCommentaryService(
            INotifier notifier,
            IReportInteractionHistoryCommentaryRepository repository
        ) : base(notifier)
        {
            _repository = repository;
        }

        public async Task Add(InteractionHistoryCommentary commentary)
        {
            await _repository.Add(commentary);
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

        public async Task<InteractionHistoryCommentary> GetById(Guid commentaryId)
        {
            return await _repository.GetById(commentaryId);
        }

        public async Task<IEnumerable<InteractionHistoryCommentary>> GetCommentariesByInteractionId(Guid interactionId)
        {
            var commentaries = await _repository
                .Find(x => x.InteractionHistoryId == interactionId && x.ParentInteractionHistoryCommentary == null);
            return commentaries.OrderBy(x => x.CreationDate);
        }

        public async Task Remove(InteractionHistoryCommentary commentary)
        {
            await _repository.Remove(commentary);
        }
    }
}