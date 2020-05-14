using System;
using System.Threading.Tasks;
using AcessaCity.Business.Interfaces.Repository;

namespace AcessaCity.Business.App.Reports
{
    public class ReportCoordinatorUpdate
    {
        private readonly IReportRepository _reportRepository;        

        public ReportCoordinatorUpdate(IReportRepository reportRepo)
        {
            _reportRepository = reportRepo;            
        }

        public async Task<bool> CoordinatorUpdate(Guid reportId, Guid coordinatorId)
        {
            var reportToUpdate = await _reportRepository.GetById(reportId);

            reportToUpdate.CoordinatorId = coordinatorId;
            await _reportRepository.Update(reportToUpdate);

            //to-do: disparar envio de notificação
            
            return true;
        }
    }
}