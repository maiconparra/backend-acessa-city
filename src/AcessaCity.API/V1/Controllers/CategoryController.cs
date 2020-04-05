using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AcessaCity.API.Controllers;
using AcessaCity.API.Dtos;
using AcessaCity.Business.Interfaces;
using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Interfaces.Service;
using AcessaCity.Business.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcessaCity.API.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/category")]    
    public class CategoryController : MainController
    {

        private readonly ICategoryRepository _repository;
        private readonly ICategoryService _service;
        private readonly INotifier _notifier;
        private readonly IMapper _mapper;

        public CategoryController(
            INotifier notifier, 
            ICategoryRepository repository,
            ICategoryService service,
            IMapper mapper) : base(notifier)
        {
            _notifier = notifier;
            _repository = repository;
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
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
            Category newCategory = new Category();
            newCategory.Name = category.Name;
            
            if (category.CategoryId != Guid.Empty)
            {
               newCategory.CategoryId = category.CategoryId;               
            }

            await _service.Add(newCategory);

            var created = _mapper.Map<CategoryDto>(newCategory);

            if (ValidOperation())
            {
                return CreatedAtAction(nameof(GetById), new {Id = newCategory.Id, Version = "1.0"}, created);                
            }

            return CustomResponse();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, CategoryUpdateDto category)
        {
            if (!id.Equals(category.Id))
            {
                NotifyError("O Id de atualização é inválido.");
                return CustomResponse();
            }

            var categoryToUpdate = await _repository.GetById(id);

            if (categoryToUpdate == null)
            {
                return NotFound();
            }

            categoryToUpdate.Name = category.Name;

            await _service.Update(categoryToUpdate);
            var updated = _mapper.Map<CategoryDto>(categoryToUpdate);

            return CustomResponse(updated);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _service.Remove(id);
            return CustomResponse();
        }

    }
}