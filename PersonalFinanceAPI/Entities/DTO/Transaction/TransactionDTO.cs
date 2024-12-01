using PersonalFinance.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.DTO.Transaction
{
    public class TransactionDTO
    {
        public Guid TransactionId { get; set; }
        public Guid UserId { get; set; }
        public TransactionType TransactionType { get; set; } = TransactionType.Expense;
        public TransactionCategory Category { get; set; } = TransactionCategory.Salary;
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    }
}
