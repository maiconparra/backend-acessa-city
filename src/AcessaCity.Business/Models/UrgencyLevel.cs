using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace AcessaCity.Business.Models
{
   public class UrgencyLevel: Entity
   {
     public string description { get; set; }

     public int priority { get; set; }
   }
}