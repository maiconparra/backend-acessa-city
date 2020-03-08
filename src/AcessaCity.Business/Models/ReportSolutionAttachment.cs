using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace AcessaCity.Business.Models
{
  public class ReportSolutionAttachment: Entity
  {
    public Guid ReportSolutionId { get; set; }
    public string MediaType { get; set; }
    public string Url { get; set; }

    [ForeignKey("ReportSolutionId")]
    public virtual ReportSolution ReportSolution { get; set; }
  }
}