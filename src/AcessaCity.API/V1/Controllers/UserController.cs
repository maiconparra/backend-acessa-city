using System;
using System.Threading.Tasks;
using AcessaCity.API.Controllers;
using AcessaCity.Business.Interfaces;
using AcessaCity.Business.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AcessaCity.API.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/user")]        
    public class UserController : MainController
    {
        private readonly IUserRepository _repository;

        public UserController(
            INotifier notifier,
            IUserRepository repository) : base(notifier)
        {
            _repository = repository;
        }

        [HttpGet("{userId:guid}/coordinators")]
        public async Task<ActionResult> GetCoordinatorsList(Guid userId)
        {
            var user = await _repository.GetById(userId);
            if (user == null)
            {
                return NotFound();
            }
            return CustomResponse(await _repository.UserCoordinators(userId));
        }
    }
}