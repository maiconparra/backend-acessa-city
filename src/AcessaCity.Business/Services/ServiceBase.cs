using AcessaCity.Business.Interfaces;
using AcessaCity.Business.Models;
using AcessaCity.Business.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace AcessaCity.Business.Services
{
    public abstract class ServiceBase
    {

        private readonly INotifier _notifier;
        public ServiceBase(INotifier notifier)        
        {
            _notifier = notifier;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        protected void Notify(string message)
        {
            _notifier.Handle(new Notification(message));
        }

        protected bool ExecuteValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validation.Validate(entity);

            if(validator.IsValid) return true;

            Notify(validator);

            return false;
        }
    }
}