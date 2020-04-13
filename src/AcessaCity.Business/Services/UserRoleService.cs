using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcessaCity.Business.Interfaces;
using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Interfaces.Service;
using AcessaCity.Business.Models;

namespace AcessaCity.Business.Services
{
    public class UserRoleService : ServiceBase, IUserRoleService
    {
        private readonly IUserRoleRepository _repository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public UserRoleService(
            INotifier notifier,
            IUserRoleRepository repository,
            IRoleRepository roleRepository,
            IUserRepository userRepository,
            IUserService userService) : base(notifier)
        {
            _repository = repository;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _userService = userService;
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

        public async Task UpdateUserRole(string role, Guid userId, bool allow)
        {
            User user = await _userRepository.GetById(userId);
            if (user == null)
            {
                Notify("Usuário não encontrado");
                return;
            }
            var findRole = await _roleRepository.Find(r => r.Name.ToLower() == role.ToLower());
            if (!findRole.Any())
            {
                Notify($"A role {role} não foi encontrada.");
                return;
            }

            Guid roleId = findRole.FirstOrDefault().Id;
            var userRoles = await _repository.Find(e => e.UserId == userId && e.RoleId == roleId);
            if (!allow)
            {                
                if (userRoles.Any())
                {
                    await _repository.Remove(userRoles.FirstOrDefault());
                }
            }
            else
            {
                if (!userRoles.Any())
                {
                    UserRoles newUserRole = new UserRoles()
                    {
                        RoleId = roleId,
                        UserId = userId
                    };

                    await _repository.Add(newUserRole);
                }
            }

            var userRolesList = await _repository.Find(r => r.UserId == userId);
            var claims = new Dictionary<string, object>();
            foreach (var item in userRolesList)
            {
                claims.Add(item.Role.Name, true);                
            }

            await _userService.UpdateUserClaims(user.FirebaseUserId, claims);
        }
    }
}