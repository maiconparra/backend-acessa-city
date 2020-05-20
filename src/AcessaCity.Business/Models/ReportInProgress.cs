using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcessaCity.Business.Models
{
  public class ReportInProgress: Entity
  {
    public Guid ReportId { get; set; }
    public Guid InteractionHistoryId { get; set; }
    public Guid UserId { get; set; }
    public Guid? OwnerUserId { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? DoneDate { get; set; }

    [ForeignKey("ReportId")]
    public virtual Report Report { get; set; }

    [ForeignKey("InteractionHistoryId")]
    public virtual InteractionHistory InteractionHistory { get; set; }

    [ForeignKey("UserId")]
    public virtual User User { get; set; }

    [ForeignKey("OwnerUserId")]
    public virtual User OwnerUser { get; set; }
  }
}