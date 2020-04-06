using System;

namespace AcessaCity.API.Dtos.ReportClassification
{
    public class ReportClassificationUpdateDto
    {
        public Guid UserId { get; set; }
        public Guid ReportId { get; set; }
        public int Rating { get; set; }
    }
}