using Entities.Models;
using PersonalFinance.Persistense.Data;
using PersonalFinance.Persistense.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Persistense.Repositories
{
    public class NotificationRepository : RepositoryBase<Notification>, INotificationRepository
    {
        public NotificationRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public void CreateNotification(Guid userId, Notification notification)
        {
            notification.UserId = userId;
            Create(notification);
        }

        public void DeleteNotification(Notification notification) => Delete(notification);
       

        public IEnumerable<Notification> GetAllNotificationsByReading(bool isRead) => FindByCondition(x => x.IsRead == isRead, false)
            .ToList();
      

        public IEnumerable<Notification> GetAllNotificationsByUserId(Guid userId) => FindByCondition(x => x.UserId == userId, false)
            .ToList();

        public Notification GetNotification(Guid notificationId, bool trackChanges) => FindByCondition(c => c.NotificationId.Equals(notificationId), trackChanges)
            .SingleOrDefault();

    }
}
