using System;
using System.Threading.Tasks;
using AcessaCity.API.Controllers;
using AcessaCity.API.Dtos.User;
using AcessaCity.Business.Dto.User;
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
        private readonly IUserService _service;

        public UserController(
            INotifier notifier,
            IUserRepository repository,
            IUserService service) : base(notifier)
        {
            _repository = repository;
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> Post(UserCreateDto user)
        {
            await _service.AddFirebaseUser(user);
            return CustomResponse();
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

        [HttpPut("update-photo-profile")]
        public async Task<ActionResult> UptePhotoProfile(UpdateUserProfilePhoto photo)
        {
            var user = await _repository.GetById(photo.UserId);
            await _service.UpdateUserPhotoUrl(user.FirebaseUserId, photo.PhotoURL);
            
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