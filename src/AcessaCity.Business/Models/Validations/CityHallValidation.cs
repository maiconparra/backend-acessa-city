using System;
using FluentValidation;

namespace AcessaCity.Business.Models.Validations
{
    public class CityHallValidation : AbstractValidator<CityHall>
    {
        public CityHallValidation()
        {

            RuleFor(c => c.Name)
                .MaximumLength(200)
                .WithMessage("O nome deve conter no máximo {MaxLength} caracteres");

            RuleFor(c => c.CNPJ)
                .Length(14, 14)
                .WithMessage("Os digitos do CNPJ não atingiram a quantidade mínima necessária.");

            RuleFor(c => c.CityId)
                .NotEqual(Guid.Empty)
                .WithMessage("O Id da cidade é obrigatório.");

            RuleFor(c => c.Address)
                .MaximumLength(200)
                .WithMessage("O enderedeço deve conter no máximo {MaxLength} caracteres");

            RuleFor(c => c.Number)
                .MaximumLength(45)
                .WithMessage("O campo número deve conter no máximo {MaxLength} caracteres");

            RuleFor(c => c.Neighborhood)
                .MaximumLength(120)
                .WithMessage("O campo bairro deve conter no máximo {MaxLength} caracteres.");
        }
    }
}