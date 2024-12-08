using PersonalFinance.Domain.DTO.Budget;
using PersonalFinance.Domain.DTO.Goal;
using PersonalFinance.Domain.DTO.Notification;
using PersonalFinance.Domain.DTO.Report;
using PersonalFinance.Domain.DTO.Transaction;
using PersonalFinance.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.DTO.UserWithDetails
{
    public class UserWithDetailsDTO
    {
        public Guid UserId { get; set; }
        public string UserFirstName { get; set; } = string.Empty;
        public string UserLastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Role Role { get; set; } = Role.User;

        // Navigation properties
        public IEnumerable<TransactionDTO> Transactions { get; set; }
        public IEnumerable<BudgetDTO> Budgets { get; set; }
        public IEnumerable<GoalDTO> Goals { get; set; }
        public IEnumerable<NotificationDTO> Notifications { get; set; }
        public IEnumerable<ReportDTO> Reports { get; set; }
    }
}
