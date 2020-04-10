using System;
using System.Threading.Tasks;
using AcessaCity.API.Controllers;
using AcessaCity.API.Dtos.ReportAttachment;
using AcessaCity.Business.Interfaces;
using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

//todo: Trocar o repository por service
namespace AcessaCity.API.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/report-attachment")]
    public class ReportAttachmentController : MainController
    {
        public readonly IReportAttachmentRepository _repository;
        public readonly IMapper _mapper;

        public ReportAttachmentController(
            INotifier notifier, 
            IReportAttachmentRepository repository,
            IMapper mapper) : base(notifier)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Add(ReportAttachmentInsertDto attachment)        
        {
            ReportAttachment newAttachment = _mapper.Map<ReportAttachment>(attachment);

            await _repository.Add(newAttachment);

            if (ValidOperation())
            {

            }
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _repository.Remove(id);
            return CustomResponse();            
        }
    }
}