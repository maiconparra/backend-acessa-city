using System;
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

        public UserRoleService(
            INotifier notifier,
            IUserRoleRepository repository,
            IRoleRepository roleRepository) : base(notifier)
        {
            _repository = repository;
            _roleRepository = roleRepository;
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

        public async Task UpdateUserRole(string role, Guid userId, bool allow)
        {
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
            
        }
    }
}