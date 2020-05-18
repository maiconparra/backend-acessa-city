using System;
using System.Threading.Tasks;
using AcessaCity.API.Controllers;
using AcessaCity.API.Dtos.ReportInteractionHistory;
using AcessaCity.Business.Interfaces;
using AcessaCity.Business.Interfaces.Service;
using AcessaCity.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcessaCity.API.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/report-interaction-history")]
    public class ReportInteractionHistoryController : MainController
    {
        private readonly IReportInteractionHistoryService _service;
        private readonly IReportInteractionHistoryCommentaryService _commentaryService;

        public ReportInteractionHistoryController(
            INotifier notifier,
            IReportInteractionHistoryService service,
            IReportInteractionHistoryCommentaryService commentaryService
            ) : base(notifier)
        {
            _service = service;
            _commentaryService = commentaryService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok();
        }        

        [HttpGet("/api/v{version:apiVersion}/report-interaction-history/report/{reportId:guid}")]
        public async Task<ActionResult> GetByReportId(Guid reportId)
        {
            return CustomResponse(await _service.InteractionsByReportId(reportId));
        }        

        [HttpGet("/api/v{version:apiVersion}/report-interaction-history/commentary/{commentaryId:guid}")]
        public async Task<ActionResult> GetCommentaryById(Guid commentaryId)
        {
            return CustomResponse(await _commentaryService.GetById(commentaryId));            
        }

        [HttpGet("/api/v{version:apiVersion}/report-interaction-history/{interactionId:guid}/commentary")]
        public async Task<ActionResult> GetCommentariesByInteractionId(Guid interactionId)
        {            
            return CustomResponse(await _commentaryService.GetCommentariesByInteractionId(interactionId));
        }

        [HttpPost("/api/v{version:apiVersion}/report-interaction-history/commentary")]
        public async Task<ActionResult> AddCommentary(ReportInteractionHistoryCommentaryInsertDto commentary)
        {
            InteractionHistoryCommentary newCommentary = new InteractionHistoryCommentary () {
                UserId = commentary.UserId,
                InteractionHistoryId = commentary.ReportInteractionHistoryId,
                InteractionHistoryCommentId = commentary.ReportInteractionHistoryCommentaryId,
                Commentary = commentary.Commentary,
                CreationDate = DateTime.Now
            };

            await _commentaryService.Add(newCommentary);
            var created = await _commentaryService.GetById(newCommentary.Id);
            return CustomResponse(created);

            // return CreatedAtAction(nameof(GetCommentaryById), new {Id = newCommentary.Id, Version = "1.0"}, created);                
        }


        
    }
}