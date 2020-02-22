using System;

namespace AcessaCity.Business.Models
{
    public class Category: Entity
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }

        //EF Relations
        public Category ParentCategory { get; set; }
    }
}