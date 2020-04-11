using System;
using System.Threading.Tasks;
using AcessaCity.Business.Dtos.City;

namespace AcessaCity.Business.Interfaces.Service
{
    public interface IGeolocationService : IDisposable
    {
        Task<CityResultFromGeolocation> GetCityInfoFromLocation(double latitude, double longitude);         
    }
}