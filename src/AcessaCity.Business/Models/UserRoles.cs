using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace AcessaCity.Business.Models
{
  public class UserRoles: Entity
  {
     public Guid? userId { get; set; }
     [ForeignKey("userId")]

     public Guid? rolesId { get; set; }
     [ForeignKey("rolesId")]
    
  }
}