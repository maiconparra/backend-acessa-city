using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace AcessaCity.Business.Models
{
  public class ReportClassification: Entity
  {
    public Guid ReportId { get; set; }
    public Guid UserId { get; set; }
    public int Rating { get; set; }

    [ForeignKey("ReportId")]
    public virtual Report Report { get; set; }
    
    [ForeignKey("UserId")]
    public virtual User User { get; set; }
  }
}