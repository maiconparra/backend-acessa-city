using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;



namespace AcessaCity.Business.Models
{
   public class CityHallRelatedUser: Entity
   {
      public Guid? userId { get; set; }
      [ForeignKey("userId")]

      public Guid? cityHallId { get; set; }
      [ForeignKey("cityHallId")]
   }
}