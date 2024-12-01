using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.DTO.Notification
{
    public class AddNotificationDTO
    {
        public Guid UserId { get; set; }
        public string Message { get; set; } = string.Empty;      
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
    }
}
