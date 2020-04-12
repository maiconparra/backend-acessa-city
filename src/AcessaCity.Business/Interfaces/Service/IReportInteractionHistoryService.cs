using System;
using System.Threading.Tasks;
using AcessaCity.Business.Models;

namespace AcessaCity.Business.Interfaces.Service
{
    public interface IReportInteractionHistoryService : IDisposable
    {
        Task Add(InteractionHistory interaction);
    }
}