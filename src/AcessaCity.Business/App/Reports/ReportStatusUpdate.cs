using System;
using System.Threading.Tasks;
using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Models;

namespace AcessaCity.Business.App.Reports
{
    public class ReportStatusUpdate
    {
        private readonly IReportRepository _reportRepository;
        private readonly IReportInteractionHistoryRepository _interactionRepository;

        public ReportStatusUpdate(
            IReportRepository reportRepository,
            IReportInteractionHistoryRepository interactionRepository
            )
        {
            _interactionRepository = interactionRepository;
            _reportRepository = reportRepository;
        }
        
        public async Task<bool> StatusUpdate(Guid userId, Guid reportId, Guid newStatusId, string updateDescription)
        {
            var reportToUpdate = await _reportRepository.GetById(reportId);
            
            Guid oldStatus = reportToUpdate.ReportStatusId;
            reportToUpdate.ReportStatusId = newStatusId;

            await _reportRepository.Update(reportToUpdate);

            InteractionHistory interaction = new InteractionHistory()
            {
                UserId = userId,
                ReportId = reportId,
                oldReportStatusId = oldStatus,
                NewReportStatusId = newStatusId,
                Description = updateDescription,
                CreationDate = DateTime.Now
            };

            await _interactionRepository.Add(interaction);

            return true;
        }
    }
}