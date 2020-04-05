using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;



namespace AcessaCity.Business.Models
{
  public class UserNotification: Entity
  {
     public Guid? userId { get; set; }
     [ForeignKey("userId")]

     public string title { get; set; }

     public string shortDescription { get; set; }

     public string urlClickDestination { get; set; }

     public Boolean read { get; set; }

  }
}