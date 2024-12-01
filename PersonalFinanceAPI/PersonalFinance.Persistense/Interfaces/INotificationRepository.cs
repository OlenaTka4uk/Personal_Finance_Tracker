using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Persistense.Interfaces
{
    public interface INotificationRepository
    {
        IEnumerable<Notification> GetAllNotificationsByUserId(Guid userId);
        IEnumerable<Notification> GetAllNotificationsByReading(bool isRead);
        void CreateNotification(Notification notification);
    }
}
