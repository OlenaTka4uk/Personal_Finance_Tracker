using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class SavingsGoalDTO
    {
        public decimal TargetAmount { get; set; }
        public decimal CurrentSavings { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
    }
}
