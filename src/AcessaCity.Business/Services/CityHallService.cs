using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AcessaCity.Business.Interfaces;
using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Interfaces.Service;
using AcessaCity.Business.Models;
using AcessaCity.Business.Models.Validations;
using FirebaseAdmin.Auth;

namespace AcessaCity.Business.Services
{
    public class CityHallService : ServiceBase, ICityHallService
    {
        private readonly ICityHallRepository _repository;
        private readonly IUserService _userService;
        private readonly FirebaseAuth _firebaseAuth;
        private readonly IUserRoleService _roleService;
        public CityHallService(
            INotifier notifier,
            ICityHallRepository repository,
            IUserService userService,
            FirebaseAuth firebaseAuth,
            IUserRoleService roleService) : base(notifier)
        {
            _repository = repository;
            _firebaseAuth = firebaseAuth;
            _userService = userService;
            _roleService = roleService;
        }

        public async Task Add(CityHall cityHall)
        {
            if (!ExecuteValidation(new CityHallValidation(), cityHall)) return;

            bool userExists = await _userService.FirebaseUserExistsByEmail(cityHall.Email); 
            if (userExists)
            {
                Notify("Endereço de e-mail já cadastrado no sistema.");

                return;
            }

            await _repository.Add(cityHall);

            CityHall newCityHall = await _repository.GetById(cityHall.Id);
            if (newCityHall != null)
            {
                UserRecordArgs args = new UserRecordArgs()
                {
                    DisplayName = newCityHall.Name,
                    Email = newCityHall.Email,
                    Password = newCityHall.CNPJ                    
                };             

                UserRecord fbUser = await _firebaseAuth.CreateUserAsync(args);

                if (fbUser != null)
                {
                    User newUser = new User() {
                        FirebaseUserId = fbUser.Uid,
                        Email = fbUser.Email,
                        CreationDate = DateTime.Now,
                        FirstName = fbUser.DisplayName
                    };

                    await _userService.Add(newUser);

                    var claims = new Dictionary<string, object>()
                    {
                        { "app_user_id", newUser.Id },
                        { "user", true },
                        { "city_hall", true }
                    };       

                    await _roleService.UpdateUserClaims(newUser.Id , claims);
                }
            }
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