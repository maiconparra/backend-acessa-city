using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcessaCity.Business.Models
{
   public class CityHallRelatedUser: Entity
   {
      public Guid UserId { get; set; }
      public Guid CityHallId { get; set; }

      [ForeignKey("UserId")]
      public virtual User RelatedUser { get; set; }

      [ForeignKey("CityHallId")]
      public CityHall RelatedCityHall { get; set; }
   }
}