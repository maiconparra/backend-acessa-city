using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace AcessaCity.Business.Models
{
  public class ReportSolution: Entity
  {
     public Guid? userId { get; set; }
     [ForeignKey("userId")]

     public Guid? reportId { get; set; }
     [ForeignKey("reportId")]

     public Guid? reportStatusId { get; set; }
     [ForeignKey("reportStatusId")]

     public string description { get; set; }
  }
}