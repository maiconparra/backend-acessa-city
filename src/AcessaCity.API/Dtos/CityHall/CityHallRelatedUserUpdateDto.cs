using System;

namespace AcessaCity.API.Dtos.CityHall
{
    public class CityHallRelatedUserUpdateDto
    {
        public Guid CityHallId { get; set; }
        public Guid UserId { get; set; }
        public bool AllowUser { get; set; }
    }
}