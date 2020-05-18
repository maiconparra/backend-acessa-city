using System;

namespace AcessaCity.API.Dtos.ReportInteractionHistory
{
    public class ReportInteractionHistoryCommentaryInsertDto
    {
        public Guid UserId { get; set; }
        public Guid ReportInteractionHistoryId { get; set; }
        public Guid? ReportInteractionHistoryCommentaryId { get; set; }
        public String Commentary { get; set; }        
    }
}