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

        public UserService(INotifier notifier, IUserRepository repository, FirebaseAuth firebaseAuth) : base(notifier)
        {
            _repo = repository;
            _firebaseAuth = firebaseAuth;
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
                    ProfileUrl = fbUser.PhotoUrl
                };

                await Add(newUser);

                var claims = new Dictionary<string, object>()
                {
                    { "app_user_id", newUser.Id },
                    { "user", true },
                    { user.Roles[0], true }
                };

                await UpdateUserClaims(fbUser.Uid, claims);
            }

            return newUser;
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

        public async Task UpdateUserClaims(string firebaseUserId, Dictionary<string, object> claims)
        {
            var user = await this.FindUserByFirebaseId(firebaseUserId);
            if (!claims.ContainsKey("app_user_id"))
            {
                claims.Add("app_user_id", user.Id);
            }            
            await _firebaseAuth.SetCustomUserClaimsAsync(firebaseUserId, claims);            
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