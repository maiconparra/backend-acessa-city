using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcessaCity.Business.Dto.User;
using AcessaCity.Business.Interfaces;
using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Interfaces.Service;
using AcessaCity.Business.Models;
using FirebaseAdmin.Auth;

namespace AcessaCity.Business.Services
{
    public class UserService : ServiceBase, IUserService
    {
        private readonly IUserRepository _repo;
        private readonly FirebaseAuth _firebaseAuth;
        private readonly IUserRoleService _userRoleService;

        public UserService(INotifier notifier,
            IUserRepository repository, 
            FirebaseAuth firebaseAuth,
            IUserRoleService userRoleService) : base(notifier)
        {
            _repo = repository;
            _firebaseAuth = firebaseAuth;
            _userRoleService = userRoleService;
        }

        public async Task Add(User user)
        {
            await _repo.Add(user);
        }

        public async Task<User> AddFirebaseUser(UserCreateDto user)
        {
            User newUser = null;
            if (await this.FirebaseUserExistsByEmail(user.Email)) 
            {
                Notify($"O usuário {user.Email} já existe");  
                return newUser;
            }          

            if (!user.Roles.Any())
            {
                Notify("Não é possível criar um usuário sem as definições de níveis de acesso");
                return newUser;
            }

            UserRecordArgs args = new UserRecordArgs()
            {
                Email = user.Email,
                EmailVerified = user.EmailVerified,
                PhoneNumber = user.PhoneNumber,
                Password = user.Password,
                DisplayName = user.DisplayName,
                PhotoUrl = user.PhotoUrl,
                Disabled = false,
            };            

            var fbUser = await FirebaseAuth.DefaultInstance.CreateUserAsync(args);
            if (fbUser != null)
            {
                    newUser = new User() {
                    FirebaseUserId = fbUser.Uid,
                    Email = fbUser.Email,
                    CreationDate = DateTime.Now,
                    FirstName = fbUser.DisplayName,
                    ProfileUrl = fbUser.PhotoUrl,
                    CityHallId = user.CityHallId
                };

                await Add(newUser);

                var claims = new Dictionary<string, object>()
                {
                    { "app_user_id", newUser.Id },
                    { "user", true },
                    { user.Roles[0], true }
                };

                await _userRoleService.UpdateUserRole("user", newUser.Id, true);
                await _userRoleService.UpdateUserRole(user.Roles[0], newUser.Id, true);

                await _userRoleService.UpdateUserClaims(newUser.Id, claims);
            }

            return newUser;
        }

        public async Task<IEnumerable<User>> AllUsersByCityHallId(Guid Id)
        {
            return await _repo.Find(x => x.CityHallId == Id);
        }

        public void Dispose()
        {
            _repo?.Dispose();
        }

        public Task<User> FindById(Guid Id)
        {
            return _repo.GetById(Id);
        }

        public async Task<User> FindUserByFirebaseId(string firebaseUserId)
        {
            var user = await _repo.Find(u => u.FirebaseUserId == firebaseUserId);

            return user.FirstOrDefault();
        }

        public async Task<bool> FirebaseUserExistsByEmail(string email)
        {
            try {                
                var user = await _firebaseAuth.GetUserByEmailAsync(email);
                return user != null;
            } catch (FirebaseAuthException ex) {
            }
            return false;
        }

        public async Task Update(User user)
        {
            await _repo.Update(user);
        }

        public async Task<bool> UpdateUserData(string firebaseUserId, string firstName, string lastName)
        {
            UserRecordArgs args = new UserRecordArgs()
            {
                Uid = firebaseUserId,
                DisplayName = $"{firstName} {lastName}"
            };             

            return await _firebaseAuth.UpdateUserAsync(args) != null;
        }

        public async Task<bool> UpdateUserEmail(string firebaseUserId, string oldEmail, string email)
        {
            var currentUserUpdate = await _firebaseAuth.GetUserByEmailAsync(oldEmail);

            if (await FirebaseUserExistsByEmail(email))
            {
                var user = await _firebaseAuth.GetUserByEmailAsync(email);
                if (user.Uid != currentUserUpdate.Uid)
                {
                    Notify($"O e-mail {email} já está em uso por outro usuário.");
                    return false;
                }
            }

            UserRecordArgs args = new UserRecordArgs()
            {
                Uid = firebaseUserId,
                Email = email
            };             

            return await _firebaseAuth.UpdateUserAsync(args) != null;
        }

        public async Task<bool> UpdateUserPhotoUrl(string firebaseUserId, string photoUrl)
        {
            UserRecordArgs args = new UserRecordArgs()
            {
                Uid = firebaseUserId,
                PhotoUrl = photoUrl
            };             
            return await _firebaseAuth.UpdateUserAsync(args) != null;
        }
    }
}