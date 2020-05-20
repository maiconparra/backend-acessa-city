using System;
using System.Linq;
using System.Threading.Tasks;
using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Models;

namespace AcessaCity.Business.App.Reports
{
    public class ReportStatusUpdate
    {
        private readonly IReportRepository _reportRepository;
        private readonly IReportInteractionHistoryRepository _interactionRepository;
        private readonly IReportInProgressRepository _progressRepo;
        private readonly IReportStatusRepository _statusRepository;

        public ReportStatusUpdate(
            IReportRepository reportRepository,
            IReportInteractionHistoryRepository interactionRepository,
            IReportInProgressRepository progressRepo,
            IReportStatusRepository statusRepository
            )
        {
            _interactionRepository = interactionRepository;
            _reportRepository = reportRepository;
            _progressRepo = progressRepo;
            _statusRepository = statusRepository;
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

            var currentStatus = await _statusRepository.GetById(newStatusId);

            if (currentStatus.InProgress)
            {
                var records = await _progressRepo.Find(x => x.ReportId == reportToUpdate.Id);
                
                if (!records.Any())
                {
                    ReportInProgress inProgress = new ReportInProgress()
                    {
                        InteractionHistoryId = interaction.Id,
                        ReportId = reportToUpdate.Id,
                        UserId = interaction.UserId,                        
                        CreationDate = DateTime.Now
                    };

                    //TO-DO: Disparar notificacao para os usuários
                    await _progressRepo.Add(inProgress);
                }
            }

            return true;
        }
    }
}