using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;



namespace AcessaCity.Business.Models
{
   public class ReportAttachment: Entity
   {
      public Guid? reportId { get; set; }
      [ForeignKey("reportId")]

      public string meidaType { get; set; }

      public string url { get; set; }
   }
}