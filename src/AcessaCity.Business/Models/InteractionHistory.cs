using System;

namespace AcessaCity.Business.Models
{
   public class InteractionHistory: Entity
   {
      public Guid UserId { get; set; }
      public Guid ReportId { get; set; }
      public Guid NewReportStatusId { get; set; }
      public Guid? oldReportStatusId { get; set; }
      public string Description { get; set; }
      public DateTime CreationDate { get; set; }
   }
}