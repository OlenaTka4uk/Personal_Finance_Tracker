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
        public string UserFirstName { get; set; } = string.Empty;
        public string UserLastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Role Role { get; set; } = Role.User;

        // Navigation properties
        public ICollection<TransactionDTO> Transactions { get; set; }
        public ICollection<BudgetDTO> Budgets { get; set; }
        public ICollection<GoalDTO> Goals { get; set; }
        public ICollection<NotificationDTO> Notifications { get; set; }
        public ICollection<ReportDTO> Reports { get; set; }
    }
}
