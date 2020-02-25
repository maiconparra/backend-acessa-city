using System.Collections.Generic;
using System.Threading.Tasks;
using AcessaCity.API.Controllers;
using AcessaCity.Business.Interfaces;
using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcessaCity.API.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/category")]    
    public class CategoryController : MainController
    {

        private readonly ICategoryRepository _repository;
        private readonly INotifier _notifier;
        public CategoryController(
            INotifier notifier, 
            ICategoryRepository repository) : base(notifier)
        {
            _notifier = notifier;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            return await _repository.GetAll();
        }
    }
}