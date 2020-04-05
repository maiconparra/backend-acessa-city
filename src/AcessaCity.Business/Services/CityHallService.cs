using System.Threading.Tasks;
using AcessaCity.Business.Interfaces;
using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Interfaces.Service;
using AcessaCity.Business.Models;
using AcessaCity.Business.Models.Validations;

namespace AcessaCity.Business.Services
{
    public class CityHallService : ServiceBase, ICityHallService
    {
        private readonly ICityHallRepository _repository;
        public CityHallService(
            INotifier notifier,
            ICityHallRepository repository) : base(notifier)
        {
            _repository = repository;
        }

        public async Task Add(CityHall cityHall)
        {
            if (!ExecuteValidation(new CityHallValidation(), cityHall)) return;

            await _repository.Add(cityHall);
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

        public Task Remove(CityHall id)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(CityHall category)
        {
            throw new System.NotImplementedException();
        }
    }
}