using System;
using System.ComponentModel.DataAnnotations;

namespace AcessaCity.API.Dtos
{
    public class CategoryInsertDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(120, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
    }
}