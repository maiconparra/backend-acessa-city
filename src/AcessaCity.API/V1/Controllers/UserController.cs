using System;
using System.Threading.Tasks;
using AcessaCity.API.Controllers;
using AcessaCity.API.Dtos.User;
using AcessaCity.Business.Interfaces;
using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Interfaces.Service;
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

        [HttpPost]
        public async Task<ActionResult> Post()
        {
            return Ok();
        }

        [HttpPut("{userId:guid}/update-role")]
        public async Task<ActionResult> UdpdateUserRole(
            Guid userId, 
            UpdateUserRoleDto role,
            [FromServices] IUserRoleService roleService)
        {
            await roleService.UpdateUserRole(role.Role, userId, role.Allow);

            return CustomResponse();
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