using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace AcessaCity.Business.Models
{
  public class UserRoles : Entity
  {
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }

    [ForeignKey("UserId")]
    public virtual User User { get; set; }

    [ForeignKey("RoleId")]
    public virtual Role Role { get; set; }
    
  }
}