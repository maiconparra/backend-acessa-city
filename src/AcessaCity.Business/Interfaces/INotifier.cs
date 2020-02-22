using System.Collections.Generic;
using AcessaCity.Business.Notifications;

namespace AcessaCity.Business.Interfaces
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}