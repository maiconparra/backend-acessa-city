using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcessaCity.Business.Models
{
    public class Report: Entity
    {
        public Guid? userId { get; set; }
        [ForeignKey("userId")]

        public Guid? categoryId { get; set; }
        [ForeignKey("categoryId")]

        public Guid? urgencyLevelId { get; set; }
        [ForeignKey("urgencyLevelId")]

        public Guid? reportStatusId { get; set; }
        [ForeignKey("reportStausId")]

        public string title { get; set; }

        public string description { get; set; }

        public decimal latitude { get; set; }

        public decimal longitude { get; set; }

        public decimal accuracy { get; set; }

        public DateTime creationDate { get; set; }
    }
}