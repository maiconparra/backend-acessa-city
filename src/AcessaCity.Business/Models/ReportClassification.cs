using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace AcessaCity.Business.Models
{
  public class ReportClassification: Entity
  {
     public string reportId { get; set; }
     [ForeignKey("reportId")]

     public string userId { get; set; }
     [ForeignKey("userId")]

     public int rating { get; set; }
  }
}