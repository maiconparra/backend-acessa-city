using System.Threading.Tasks;
using AcessaCity.Business.Interfaces;
using AcessaCity.Business.Interfaces.Service;
using AcessaCity.Business.Models;

namespace AcessaCity.Business.Services
{
    public class ReportInteractionHistoryService : ServiceBase, IReportInteractionHistoryService
    {

        

        public ReportInteractionHistoryService(INotifier notifier) : base(notifier)
        {
        }

        public Task Add(InteractionHistory interaction)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}