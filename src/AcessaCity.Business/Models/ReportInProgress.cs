using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;



namespace AcessaCity.Business.Models
{
  public class ReportInProgress: Entity
  {
     public Guid? reportId { get; set; }
     [ForeignKey("reportId")]

     public Guid? interactionHistoryId { get; set; }
     [ForeignKey("interactionHistoryId")]

     public Guid? userId { get; set; }
     [ForeignKey("userId")]

     public DateTime creationDate { get; set; }

     public DateTime estimatadeFinishDate { get; set; }

     public DateTime startDate { get; set; }

     public DateTime doneDate { get; set; }
  }
}