using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcessaCity.Business.Interfaces.Service
{
    public interface IUserRoleService : IDisposable
    {
        Task UpdateUserRole(string role, Guid userId, bool allow);
        Task UpdateUserClaims(Guid userId, Dictionary<string, object> claims);
    }
}