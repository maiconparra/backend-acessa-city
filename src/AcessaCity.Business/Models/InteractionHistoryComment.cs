using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcessaCity.Business.Models
{
   public class InteractionHistoryComment: Entity
   {
      public Guid UserId { get; set; }

      public Guid InteractionHistoryId { get; set; }

      public Guid? InteractionHistoryCommentId { get; set; }
      
      [ForeignKey("InteractionHistoryCommentId")]
      public virtual InteractionHistoryComment ParentInteractionHistoryComment { get; set; }

      public virtual IEnumerable<InteractionHistoryComment> InteractionHistoryComments { get; set; }
      
   }
}