using System;
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
        
        public ReportController(
            INotifier notifier,
            IReportRepository repository,
            IReportService service,
            IMapper mapper) : base(notifier)
        {
            _service = service;
            _repository = repository;
            _mapper = mapper;
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