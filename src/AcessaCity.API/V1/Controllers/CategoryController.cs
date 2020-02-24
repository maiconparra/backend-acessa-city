using AcessaCity.API.Controllers;
using AcessaCity.Business.Interfaces;
using AcessaCity.Business.Interfaces.Repository;

namespace AcessaCity.API.V1.Controllers
{
    public class CategoryController : MainController
    {

        private readonly ICategoryRepository _repository;
        public CategoryController(INotifier notifier) : base(notifier)
        {
        }
    }
}