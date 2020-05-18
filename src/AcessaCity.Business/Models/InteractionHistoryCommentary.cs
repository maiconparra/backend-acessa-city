using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcessaCity.Business.Models
{
   public class InteractionHistoryCommentary: Entity
   {
      public Guid UserId { get; set; }
      public Guid InteractionHistoryId { get; set; }
      public Guid? InteractionHistoryCommentId { get; set; }
      public string Commentary { get; set; }
      public DateTime CreationDate { get; set; }
      
      [ForeignKey("InteractionHistoryCommentId")]
      public virtual InteractionHistoryCommentary ParentInteractionHistoryCommentary { get; set; }

      public virtual IEnumerable<InteractionHistoryCommentary> InteractionHistoryCommentaries { get; set; }

      public virtual User User { get; set; }
      
   }
}