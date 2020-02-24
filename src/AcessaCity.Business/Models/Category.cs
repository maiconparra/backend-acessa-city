using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcessaCity.Business.Models
{
    public class Category: Entity
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }

        //EF Relations
        [ForeignKey("CategoryId")]
        public Category ParentCategory { get; set; }

        public IEnumerable<Category> Categories { get; set; }

    }
}