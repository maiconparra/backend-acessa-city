using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AcessaCity.Business.Models;

namespace AcessaCity.Business.Interfaces.Repository
{
    public interface ICityHallRelatedUserRepository : IRepository<CityHallRelatedUser>
    {
        Task<IEnumerable<User>> AllRelatedUsers(Guid cityhallId);         
    }
}