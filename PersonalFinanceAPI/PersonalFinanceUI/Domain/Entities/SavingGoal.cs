using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SavingGoal
    {
        public int GoalId { get; set; }
        public int UserId { get; set; }
        public decimal TargetAmount { get; set; }
        public decimal CurrentSavings { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }

        //Navigation property
        public User User { get; set; }
    }
}
