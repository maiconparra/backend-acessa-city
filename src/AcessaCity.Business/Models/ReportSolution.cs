using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace AcessaCity.Business.Models
{
  public class ReportSolution: Entity
  {
    public Guid UserId { get; set; }
    public Guid ReportId { get; set; }
    public Guid? ReportStatusId { get; set; }
    public string Description { get; set; }

    [ForeignKey("UserId")]
    public virtual User User { get; set; }

    [ForeignKey("ReportId")]
    public virtual Report Report { get; set; }
    
    [ForeignKey("ReportStatusId")]
    public virtual ReportStatus ReportStatus { get; set; }
  }
}