using System;

namespace AcessaCity.API.Dtos.ReportAttachment
{
    public class ReportAttachmentInsertDto
    {
        public Guid ReportId { get; set; }
        public string MediaType { get; set; }
        public string URL { get; set; }        
    }
}