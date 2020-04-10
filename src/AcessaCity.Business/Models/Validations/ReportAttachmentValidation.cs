using FluentValidation;

namespace AcessaCity.Business.Models.Validations
{
    public class ReportAttachmentValidation : AbstractValidator<ReportAttachment>
    {
        public ReportAttachmentValidation()
        {
            RuleFor(a => a.MediaType)
                .Matches("jpg|mp4");
        }
        
    }
}