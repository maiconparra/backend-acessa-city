using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AcessaCity.API.Controllers;
using AcessaCity.API.Dtos;
using AcessaCity.Business.Interfaces;
using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AcessaCity.API.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/category")]    
    public class CategoryController : MainController
    {

        private readonly ICategoryRepository _repository;
        private readonly INotifier _notifier;
        private readonly IMapper _mapper;

        public CategoryController(
            INotifier notifier, 
            ICategoryRepository repository,
            IMapper mapper) : base(notifier)
        {
            _notifier = notifier;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> Get()
        {
            return _mapper.Map<IEnumerable<CategoryDto>>(await _repository.GetAll());        
        }

        [HttpGet("{id:guid}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDto>> GetById(Guid id)
        {
            CategoryDto category = _mapper.Map<CategoryDto>(await _repository.GetById(id));

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        [HttpPost]
        public async Task<ActionResult> Add(CategoryInsertDto category)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            Category newCategory = new Category();
            newCategory.Name = category.Name;
            
            if (category.CategoryId != Guid.Empty)
            {
               newCategory.CategoryId = category.CategoryId;
            }
            await _repository.Add(newCategory);

            return CreatedAtAction(nameof(GetById), new {Id = newCategory.Id, Version = "1.0"}, null);
        }

    }
}