using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcessaCity.Business.Models
{
    public class CityHallRelatedUser : Entity
    {
        public Guid CityHallId { get; set; }
        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public virtual CityHall CityHall { get; set; }
    }
}