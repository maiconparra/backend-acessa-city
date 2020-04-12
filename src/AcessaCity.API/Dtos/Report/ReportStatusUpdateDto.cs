using System;

namespace AcessaCity.API.Dtos.Report
{
    public class ReportStatusUpdateDto
    {
        public Guid UserId { get; set; }
        public Guid ReportStatusId { get; set; }
        public string Description { get; set; }
    }
}