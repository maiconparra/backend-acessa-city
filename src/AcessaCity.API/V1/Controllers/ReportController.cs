using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcessaCity.API.Controllers;
using AcessaCity.API.Dtos.Report;
using AcessaCity.Business.App.Reports;
using AcessaCity.Business.Interfaces;
using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Interfaces.Service;
using AcessaCity.Business.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult> Get(
            [FromQuery]Guid category, 
            [FromQuery]DateTime date,
            [FromQuery]Guid status,
            [FromQuery]Guid city,
            [FromQuery]string street,
            [FromQuery]string neighborhood,
            [FromQuery]Guid coordinatorId)
        {
            var reportList = await _repository.Find(r =>
                (r.CategoryId == category || category == Guid.Empty)
                &&
                (r.ReportStatusId == status || status == Guid.Empty)
                &&
                (r.CoordinatorId == coordinatorId || coordinatorId == Guid.Empty)
                &&                
                (r.CityId == city || city == Guid.Empty)
                &&
                (r.Street.ToLower().Contains(street.ToLower()) || street == null)
                &&
                (r.Neighborhood.ToLower().Contains(neighborhood.ToLower()) || neighborhood == null)                
                &&
                ((r.CreationDate.DayOfYear == date.DayOfYear) || date.DayOfYear == DateTime.MinValue.DayOfYear)
            );

            return CustomResponse(reportList);            
        }

        [HttpGet("{id:guid}/{date:datetime}")]
        public async Task<ActionResult> Get([FromQuery]Guid? category, [FromQuery]DateTime date)
        {
            var reportList = await _repository.Find(r =>
                (r.CategoryId == category || category == Guid.Empty) &
                (r.CreationDate.DayOfYear == date.DayOfYear || date == null) 
            );

            return CustomResponse(reportList.ToList());
        }

        [HttpPost]
        public async Task<ActionResult> Post(
            ReportInsertDto report,
            [FromServices] ReportStatusUpdate statusUpdater          
            )
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
            newReport.Street = city.Street;
            newReport.Neighborhood = city.Neighborhood;
            await _service.Add(newReport);

            if (ValidOperation())
            {
                var created = await _repository.GetById(newReport.Id);

                await statusUpdater.StatusUpdate(
                    newReport.UserId,
                    newReport.Id,
                    newReport.ReportStatusId,
                    "Denúncia criada"
                );

                return CreatedAtAction(nameof(GetById), new {Id = newReport.Id, Version = "1.0"}, created);                
            }

            return CustomResponse();
        }

        [HttpPost("{reportId:guid}/status-update")]
        public async Task<ActionResult> StatusUpdate(
            Guid reportId, 
            ReportStatusUpdateDto status,
            [FromServices]ReportStatusUpdate updater)
        {
            await updater.StatusUpdate(status.UserId, reportId, status.ReportStatusId, status.Description);
            return Ok();
        }

        [HttpPost("{reportId:guid}/coordinator-update")]
        public async Task<ActionResult> CoordinatorUpdate(
            Guid reportId, 
            ReportCoordinatorUpdateDto coordinator,
            [FromServices]ReportCoordinatorUpdate updater)
        {
            await updater.CoordinatorUpdate(reportId, coordinator.CoordinatorId);            
            return Ok();
        }
    }
}