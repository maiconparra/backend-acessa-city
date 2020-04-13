using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AcessaCity.API.Controllers;
using AcessaCity.Business.Interfaces;
using AcessaCity.Business.Interfaces.Service;
using AcessaCity.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcessaCity.API.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/auth")]
    public class AuthController : MainController
    {
        private readonly IUserService _service;
        public AuthController(INotifier notifier, IUserService service) : base(notifier)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Login()
        {
            var authUser = this.CurrentUser();
            //busca o usuario no banco
            var usuario = await _service.FindUserByFirebaseId(authUser.Uid);

            if (usuario != null)
            {
                return Ok(
                    authUser
                );
            }

            User newUser = new User();
            newUser.FirebaseUserId = authUser.Uid;
            newUser.FirstName = authUser.DisplayName;
            
            newUser.Email = authUser?.Email;
            newUser.ProfileUrl = authUser?.PhotoUrl;
            newUser.CreationDate = DateTime.Now;

            await _service.Add(newUser);

            var claims = new Dictionary<string, object>()
            {
                { "app_user_id", newUser.Id },
                { "user", true }
            };       

            await _service.UpdateUserClaims(this.CurrentUser().Uid, claims);
            this.RefreshCurrentUser();

            return Ok(
                this.CurrentUser()
            );
        }
    }
}