using FluentValidation;

namespace AcessaCity.Business.Models.Validations
{
    public class ReportValidation : AbstractValidator<Report>
    {
        public ReportValidation()
        {
            RuleFor(r => r.Title)
                .MaximumLength(200)
                .WithMessage("O título da denúncia deve conter no máximo {MaxLength} caracteres");
        }
        
    }
}