using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcessaCity.API.Controllers;
using AcessaCity.API.Dtos.Report;
using AcessaCity.Business.Interfaces;
using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Interfaces.Service;
using AcessaCity.Business.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AcessaCity.API.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/report")]        
    public class ReportController : MainController
    {
        private readonly IReportService _service;
        private readonly IReportRepository _repository;
        private readonly IMapper _mapper;
        private readonly IGeolocationService _geolocation;
        private readonly ICityRepository _cityRepository;
        
        public ReportController(
            INotifier notifier,
            IReportRepository repository,
            IReportService service,
            IMapper mapper,
            IGeolocationService geolocation,
            ICityRepository cityRepository) : base(notifier)
        {
            _service = service;
            _repository = repository;
            _mapper = mapper;
            _geolocation = geolocation;
            _cityRepository = cityRepository;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var report = await _repository.GetById(id);
            
            return Ok(report);
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var list = await _repository.GetAll();
            
            return Ok(list);
        }

        [HttpPost]
        public async Task<ActionResult> Post(ReportInsertDto report)
        {
            Report newReport = _mapper.Map<Report>(report);
            newReport.CreationDate = DateTime.Now;

            var city = await _geolocation.GetCityInfoFromLocation(
                report.Latitude,
                report.Longitude
            );

            IEnumerable<City> cities = new List<City>();

            if (city != null)
            {
                cities = await _cityRepository.Find(
                    c => c.Name.ToLower().Contains(city.Name.ToLower())
                ); 
            }

            var cityFromRepo = cities.FirstOrDefault();
            if (cityFromRepo == null)
            {
                NotifyError("As coordenadas informadas não estão cadastradas.");
                return CustomResponse();
            }

            newReport.CityId = cityFromRepo.Id;
            await _service.Add(newReport);

            if (ValidOperation())
            {
                var created = await _repository.GetById(newReport.Id);
                return CreatedAtAction(nameof(GetById), new {Id = newReport.Id, Version = "1.0"}, created);                
            }

            return CustomResponse();
        }
    }
}