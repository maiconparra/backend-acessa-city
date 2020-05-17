using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcessaCity.Business.Dto.City.User;
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

        public async Task<bool> AddFirebaseUser(UserCreateDto user)
        {
            string userExists = null;
            try {
                await FirebaseAuth.DefaultInstance.GetUserByEmailAsync(user.Email);
            } catch (FirebaseAuthException ex) {
                userExists = ex.Message;
            }                

                if (userExists == null) 
                {
                    Notify($"O usuário {user.Email} já existe");  
                    return false;
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

            await FirebaseAuth.DefaultInstance.CreateUserAsync(args);

            return FirebaseAuth.DefaultInstance.GetUserByEmailAsync(args.Email) != null;
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
    }
}