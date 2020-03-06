using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace AcessaCity.Business.Models
{
  public class ReportSolutionAttachment: Entity
  {
     public Guid? reportSolutionId { get; set; }
     [ForeignKey("reportSolutionId")]

     public string meidaType { get; set; }

     public string url { get; set; }
  }
}