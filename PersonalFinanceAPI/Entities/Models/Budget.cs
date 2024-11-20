using PersonalFinance.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Budget
    {
        public Guid BudgetId { get; set; }
        public Guid UserId { get; set; }
        public BudgetCategory Category { get; set; } = BudgetCategory.Savings;
        public decimal Amount { get; set; }
        public decimal Spent { get; set; } = 0.0m;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Navigation properties
        public User User { get; set; }
    }
}
