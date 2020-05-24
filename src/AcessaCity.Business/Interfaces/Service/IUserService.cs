using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AcessaCity.Business.Dto.User;
using AcessaCity.Business.Models;

namespace AcessaCity.Business.Interfaces.Service
{
    public interface IUserService : IDisposable
    {
        Task Add(User user);
        Task Update(User user);

        Task<User> FindById(Guid Id);
        Task<IEnumerable<User>> AllUsersByCityHallId(Guid Id);

        Task<User> FindUserByFirebaseId(string firebaseUserId);
        Task<bool> FirebaseUserExistsByEmail(string email);
        Task<User> AddFirebaseUser(UserCreateDto user);
        Task<bool> UpdateUserPhotoUrl(string firebaseUserId, string photoUrl);
        Task<bool> UpdateUserEmail(string firebaseUserId, string oldEmail, string newEmail);
        Task<bool> UpdateUserData(string firebaseUserId, string firstName, string lastName);
    }
}