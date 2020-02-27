using System.Linq;
using AcessaCity.Business.Interfaces;
using AcessaCity.Business.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AcessaCity.API.Controllers
{
    [ApiController]
    public class MainController: ControllerBase
    {
        private readonly INotifier _notifier;

        public MainController(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected bool ValidOperation()
        {
            return !_notifier.HasNotification();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (this.ValidOperation())
            {
                return Ok
                (
                    new {
                        success = true,
                        data = result
                    }
                );
            }

            return BadRequest
            (
                new {
                    success = false,
                    errors = _notifier.GetNotifications().Select(n => n.Message)
                }
            );
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                this.InvalidModelErrorNotify(modelState);
            }

            return CustomResponse();
        }

        protected void InvalidModelErrorNotify(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var error in errors)
            {
                var errorMessage = error.Exception == null ? error.ErrorMessage : error.Exception.Message;

                NotifyError(errorMessage);
            }
        }

        void NotifyError(string message)
        {
            _notifier.Handle(new Notification(message));
        }


    }
}