namespace AcessaCity.Business.Models
{
  public class ReportStatus: Entity
  {
    public string Description { get; set; }

    public bool Denied { get; set; }

    public bool Approved { get; set; }

    public bool Review { get; set; }

    public bool InProgress { get; set; }
  }
}