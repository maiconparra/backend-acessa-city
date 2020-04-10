using System;

namespace AcessaCity.API.Dtos.Report
{
    public class ReportInsertDto
    {
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UrgencyLevelId { get; set; }
        public Guid ReportStatusId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Accuracy { get; set; }        
    }
}