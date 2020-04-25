using System;
using System.Threading.Tasks;
using AcessaCity.API.Controllers;
using AcessaCity.Business.Interfaces;
using AcessaCity.Business.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AcessaCity.API.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/state")]    
    public class StateController : MainController
    {
        private readonly IStateRepository _repository;
        private readonly ICityRepository _cityRepository;

        public StateController(
            INotifier notifier, 
            IStateRepository repository,
            ICityRepository cityRepository) : base(notifier)
        {
            _repository = repository;
            _cityRepository = cityRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return CustomResponse(await _repository.GetAll());
        }

        [HttpGet("{stateId:guid}/cities")]
        public async Task<ActionResult> GetAllCities(Guid stateId)
        {
            var list = await _cityRepository.Find(c => c.StateId == stateId);

            return CustomResponse(list);
        }
    }
}