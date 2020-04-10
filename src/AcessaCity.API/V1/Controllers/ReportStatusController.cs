using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AcessaCity.API.Controllers;
using AcessaCity.API.Dtos.ReportStatus;
using AcessaCity.Business.Interfaces;
using AcessaCity.Business.Interfaces.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AcessaCity.API.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/report-status")]
    public class ReportStatusController : MainController
    {
        private readonly IReportStatusRepository _repository;
        private readonly IMapper _mapper;

        public ReportStatusController(
            INotifier notifier,
            IReportStatusRepository repository,
            IMapper mapper
        ) : base(notifier)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(_mapper.Map<IEnumerable<ReportStatusDto>>(await _repository.GetAll()));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var status = await _repository.GetById(id);

            if (status == null)
            {
                return NotFound();
            }

            return CustomResponse(_mapper.Map<ReportStatusDto>(status));
        } 

    }
}