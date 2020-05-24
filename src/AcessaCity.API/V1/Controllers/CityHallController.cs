using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcessaCity.API.Controllers;
using AcessaCity.API.Dtos.CityHall;
using AcessaCity.Business.Interfaces;
using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Interfaces.Service;
using AcessaCity.Business.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AcessaCity.API.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/city-hall")]
    public class CityHallController : MainController
    {
        private readonly ICityHallRepository _repository;
        private readonly ICityHallService _service;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public CityHallController(
            INotifier notifier,
            ICityHallService service,
            ICityHallRepository repository,
            IUserService userService,
            IMapper mapper) : base(notifier)
        {
            _repository = repository;
            _service = service;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CityHallDto>> Get()
        {
            return _mapper.Map<IEnumerable<CityHallDto>>(await _repository.GetAll());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CityHallDto>> GetById(Guid id)
        {
            var cityHall = _mapper.Map<CityHallDto>(await _repository.GetById(id));

            if (cityHall == null)
            {
                return NotFound();
            }

            return CustomResponse(cityHall);
        }

        [HttpPost]
        public async Task<ActionResult> Add(CityHallInsertDto cityHall)
        {
            IEnumerable<CityHall> checkIfExists = await _repository.Find(c => c.CNPJ.Equals(cityHall.CNPJ));
            if (checkIfExists.Count() > 0) {
                this.NotifyError($"O CNPJ {cityHall.CNPJ} já está cadastrado no sistema");
                return CustomResponse();
            }

            CityHall newCityHall = _mapper.Map<CityHall>(cityHall);

            await _service.Add(newCityHall);
            var created = await _repository.GetById(newCityHall.Id);

            if (ValidOperation())
            {
                return CreatedAtAction(nameof(GetById), new {Id = newCityHall.Id, Version = "1.0"}, created);                
            }
            
            return CustomResponse();
        }

        [HttpPut("link-cityhall-user")]
        public async Task<ActionResult> UpdateRelatedUser(CityHallRelatedUserUpdateDto relation)
        {
            return Ok();
        }

        [HttpPut("confirm-register/{id:guid}")]        
        public async Task<ActionResult> ConfirmRegister(Guid id)
        {
            CityHall cityHall = await _repository.GetById(id);

            if (cityHall == null)
            {
                return NotFound();
            }

            cityHall.Verified = true;

            await _repository.Update(cityHall);

            return Ok();
        }

        [HttpGet("{cityhallId:Guid}/users")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers(Guid cityhallId)
        {
            return CustomResponse(
                await _userService.AllUsersByCityHallId(cityhallId)
            );
        }
    }
}