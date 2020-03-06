using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace AcessaCity.Business.Models
{
   public class InteractionHistory: Entity
   {
      public Guid? userId { get; set; }
      [ForeignKey("userId")]

      public Guid? reportId { get; set; }
      [ForeignKey("reportId")]

      public Guid? newReportStatusId { get; set; }
      [ForeignKey("newReportStatusId")]

      public Guid? oldReportStatusId { get; set; }
      [ForeignKey("oldReportStatusId")]

      public string description { get; set; }

      public DateTime creationDate { get; set; }
   }
}