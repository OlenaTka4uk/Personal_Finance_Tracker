using PersonalFinance.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.DTO.Budget
{
    public class UpdateBudgetDTO
    {
        public BudgetCategory Category { get; set; } = BudgetCategory.Savings;
        public decimal Amount { get; set; }
        public decimal Spent { get; set; } = 0.0m;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
