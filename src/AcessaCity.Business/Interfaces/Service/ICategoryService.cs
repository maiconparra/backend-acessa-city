using System;
using System.Threading.Tasks;
using AcessaCity.Business.Models;

namespace AcessaCity.Business.Interfaces.Service
{
    public interface ICategoryService : IDisposable
    {
        Task Add(Category category);
        Task Update(Category category);
        Task Remove(Guid id);
    }
}