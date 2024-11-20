using PersonalFinance.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Account
    {
        public Guid AccountId { get; set; }
        public Guid UserId { get; set; }
        public string AccountName { get; set; } = "Default Account";
        public AccountType AccountType { get; set; } = AccountType.Bank;
        public decimal CurrentBalance { get; set; } = 0.0m;
        public Currency Currency { get; set; } = Currency.USD;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public User User { get; set; }
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
