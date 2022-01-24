using LogYourself.Models;

namespace LogYourself.Services
{
    public interface INotificationManagerService
    {
        void RemoveNotification(NotificationModel model);

        void AddOrUpdateNotification(NotificationModel model);
    }
}