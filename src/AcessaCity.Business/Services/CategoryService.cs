using System;
using System.Threading.Tasks;
using AcessaCity.Business.Interfaces;
using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Interfaces.Service;
using AcessaCity.Business.Models;
using AcessaCity.Business.Models.Validations;

namespace AcessaCity.Business.Services
{
    public class CategoryService : ServiceBase, ICategoryService
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(INotifier notifier, ICategoryRepository repository) : base(notifier)
        {
            _repository = repository;
        }

        public async Task Add(Category category)
        {
            if (!ExecuteValidation(new CategoryValidation(), category)) return;

            await _repository.Add(category);
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

        public async Task Remove(Guid id)
        {
            await _repository.Remove(id);
        }

        public async Task Update(Category category)
        {
            if (!ExecuteValidation(new CategoryValidation(), category)) return;

            await _repository.Update(category);
        }
    }
}