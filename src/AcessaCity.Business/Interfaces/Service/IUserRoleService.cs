using System;
using System.Threading.Tasks;

namespace AcessaCity.Business.Interfaces.Service
{
    public interface IUserRoleService : IDisposable
    {
        Task UpdateUserRole(string role, Guid userId, bool allow);
    }
}