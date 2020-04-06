using System;
using System.Threading.Tasks;
using AcessaCity.Business.Interfaces;
using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Interfaces.Service;
using AcessaCity.Business.Models;

namespace AcessaCity.Business.Services
{
    public class ReportClassificationService : ServiceBase, IReportClassificationService
    {
        private readonly IReportClassificationRepository _repository;
        private readonly IUserRepository _userRepo;

        public ReportClassificationService(
            INotifier notifier, 
            IReportClassificationRepository repository,
            IUserRepository userRepo) : base(notifier)
        {
            _repository = repository;
            _userRepo = userRepo;
        }
        public void Dispose()
        {
            _repository?.Dispose();
        }

        public async Task UpdateUserRating(Guid userId, Guid reportId, int rating)
        {
            var user = await _userRepo.GetById(userId);
            if (user == null)
            {
                this.Notify("Usuário não encontrado.");
                return;
            }

            //mesma validacao de user para o report

            var classf = await _repository.FindUserClassification(userId, reportId);

            if (classf == null)
            {
                classf = new ReportClassification()
                {
                    UserId = userId,
                    ReportId = reportId,
                    Rating = rating
                };

                await _repository.Add(classf);
            }
            else
            {
                classf.Rating = rating;
                await _repository.Update(classf);
            }
        }
    }
}