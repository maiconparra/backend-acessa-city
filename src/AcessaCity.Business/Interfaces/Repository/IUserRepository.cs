using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AcessaCity.Business.Models;

namespace AcessaCity.Business.Interfaces.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task Inactive(Guid userId);
        Task<IEnumerable<User>> UserCoordinators(Guid userId);
    }
}