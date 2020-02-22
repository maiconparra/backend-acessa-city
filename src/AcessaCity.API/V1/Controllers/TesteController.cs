using AcessaCity.API.Controllers;
using AcessaCity.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AcessaCity.API.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/teste")]
    public class TesteController: MainController
    {
        public TesteController(INotifier notifier) : base(notifier) { }

        [HttpGet]
        public string Get()
        {
            return "Teste Nova API";
        }
    }
}