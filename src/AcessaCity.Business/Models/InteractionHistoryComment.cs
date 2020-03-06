using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace AcessaCity.Business.Models
{
   public class InteractionHistoryComment: Entity
   {
      public Guid? userId { get; set; }
      [ForeignKey("userId")]

      public Guid? interactionHistoryId { get; set; }
      [ForeignKey("interactionHistoryId")]

      public Guid? interactionHistoryCommentId { get; set; }
      [ForeignKey("interactionHistoryCommentId")]

      public virtual InteractionHistoryComment ParentInteractionHistoryComment { get; set; }

      public virtual IEnumerable<InteractionHistoryComment> InteractionHistoryCommenties { get; set; }
      
   }
}