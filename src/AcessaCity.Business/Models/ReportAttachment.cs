using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcessaCity.Business.Models
{
   public class ReportAttachment : Entity
   {
      public Guid ReportId { get; set; }
      public string MediaType { get; set; }
      public string Url { get; set; }

      [ForeignKey("ReportId")]
      public virtual Report Report { get; set; }
   }
}