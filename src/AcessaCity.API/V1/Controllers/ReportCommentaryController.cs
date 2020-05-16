using System;
using System.Threading.Tasks;
using AcessaCity.API.Controllers;
using AcessaCity.API.Dtos.ReportCommentary;
using AcessaCity.Business.Interfaces;
using AcessaCity.Business.Interfaces.Service;
using AcessaCity.Business.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AcessaCity.API.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/report-commentary")]        
    public class ReportCommentaryController : MainController
    {

        private readonly IReportCommentaryService _service;
        private readonly IMapper _mapper;

        public ReportCommentaryController(
            INotifier notifier, 
            IReportCommentaryService service,
            IMapper mapper) : base(notifier)
        {
            _service = service;
            _mapper = mapper;
        }


        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            return CustomResponse(await _service.GetById(id));
        }

        [HttpGet("/api/v{version:apiVersion}/report-commentary/report/{reportId:guid}")]
        public async Task<ActionResult> GetCommentaries(Guid reportId)
        {               
            return Ok(await _service.GetCommentsByReportId(reportId));
        }        

        [HttpPost]
        public async Task<ActionResult> Add(ReportCommentaryInsertDto commentary)
        {
            ReportCommentary newCommentary = _mapper.Map<ReportCommentary>(commentary);

            await _service.Add(newCommentary);

            if (ValidOperation())
            {
                var created = await _service.GetById(newCommentary.Id);
                return CreatedAtAction(nameof(GetById), new {Id = newCommentary.Id, Version = "1.0"}, created);                
            }

            return CustomResponse();
        }


    }
}