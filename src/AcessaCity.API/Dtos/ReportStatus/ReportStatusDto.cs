using System;

namespace AcessaCity.API.Dtos.ReportStatus
{
    public class ReportStatusDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool Denied { get; set; }
        public bool Approved { get; set; }
        public bool Review { get; set; }
        public bool InProgress { get; set; }        
    }
}