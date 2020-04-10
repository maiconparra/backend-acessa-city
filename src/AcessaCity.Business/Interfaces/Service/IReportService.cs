using System;
using System.Threading.Tasks;
using AcessaCity.Business.Models;

namespace AcessaCity.Business.Interfaces.Service
{
    public interface IReportService : IDisposable
    {
        Task Add(Report report);
        Task Update(Report report);
        Task Remove(Report id);         
    }
}