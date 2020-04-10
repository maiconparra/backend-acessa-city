using System;
using System.Threading.Tasks;
using AcessaCity.API.Controllers;
using AcessaCity.Business.Interfaces;
using AcessaCity.Business.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AcessaCity.API.V1.Controllers
{

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/urgency-level")]    
    public class UrgencyLevelController : MainController
    {
        private readonly IUrgencyLevelRepository _repository;
        
        public UrgencyLevelController(INotifier notifier, IUrgencyLevelRepository repository) : base(notifier)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {            
            return CustomResponse(await _repository.GetAll());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetById(Guid id)
        {            
            var level = await _repository.GetById(id);
            if (level == null)
            {
                return NotFound();
            }

            return CustomResponse(level);
        }        


    }
}