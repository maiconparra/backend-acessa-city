using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AcessaCity.API.Dtos
{
    public class CategoryDto
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CategoryDto Category { get; set; }
        public IEnumerable<CategoryDto> Categories { get; set; }
    }
}