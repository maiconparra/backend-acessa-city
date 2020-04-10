using System;

namespace AcessaCity.API.Dtos.ReportCommentary
{
    public class ReportCommentaryInsertDto
    {
        public Guid UserId { get; set; }
        public Guid ReportId { get; set; }
        public string Commentary { get; set; }
    }
}