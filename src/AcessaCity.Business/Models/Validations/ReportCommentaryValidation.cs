using FluentValidation;

namespace AcessaCity.Business.Models.Validations
{
    public class ReportCommentaryValidation : AbstractValidator<ReportCommentary>
    {
        public ReportCommentaryValidation()
        {
            RuleFor(r => r.Commentary)
                .NotNull()
                .NotEmpty()
                .WithMessage("O conteúdo do comentário não pode ser vazio.");
        }
        
    }
}