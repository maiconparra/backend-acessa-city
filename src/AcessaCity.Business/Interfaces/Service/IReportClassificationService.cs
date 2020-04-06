using System;
using System.Threading.Tasks;

namespace AcessaCity.Business.Interfaces.Service
{
    public interface IReportClassificationService : IDisposable
    {
        Task UpdateUserRating(Guid userId, Guid reportId, int rating);
    }
}