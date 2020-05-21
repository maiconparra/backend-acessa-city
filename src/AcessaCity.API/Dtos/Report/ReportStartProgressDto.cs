using System;

namespace AcessaCity.API.Dtos.Report
{
    public class ReportStartProgressDto
    {
        public Guid ReportId { get; set; }
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
    }
}