using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcessaCity.Business.Models
{
    public class Category: Entity
    {
        public Guid? CategoryId { get; set; }
        public string Name { get; set; }

        //EF Relations
        [ForeignKey("CategoryId")]
        public virtual Category ParentCategory { get; set; }

        public virtual IEnumerable<Category> Categories { get; set; }

    }
}