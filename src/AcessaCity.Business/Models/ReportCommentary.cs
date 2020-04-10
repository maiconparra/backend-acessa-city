using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcessaCity.Business.Models
{
    public class ReportCommentary : Entity
    {
        public Guid UserId { get; set; }
        public Guid ReportId { get; set; }
        public string Commentary { get; set; }
        public bool Approved { get; set; }
        public DateTime CreationDate { get; set; }

        [ForeignKey("ReportId")]
        public virtual Report Report { get; set; }
        
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}