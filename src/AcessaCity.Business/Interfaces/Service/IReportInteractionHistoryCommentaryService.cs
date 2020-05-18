using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AcessaCity.Business.Models;

namespace AcessaCity.Business.Interfaces.Service
{
    public interface IReportInteractionHistoryCommentaryService : IDisposable
    {
        Task Add(InteractionHistoryCommentary commentary);
        Task<InteractionHistoryCommentary> GetById(Guid commentaryId);
        Task<IEnumerable<InteractionHistoryCommentary>> GetCommentariesByInteractionId(Guid interactionId);
        Task Remove(InteractionHistoryCommentary commentary);
    }
}