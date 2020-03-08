using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcessaCity.Business.Models
{
    public class Report: Entity
    {
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UrgencyLevelId { get; set; }
        public Guid ReportStatusId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal Accuracy { get; set; }
        public DateTime CreationDate { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [ForeignKey("UrgencyLevelId")]
        public virtual UrgencyLevel UrgencyLevel { get; set; }

        [ForeignKey("ReportStatusId")]
        public virtual ReportStatus ReportStatus { get; set; }
    }
}