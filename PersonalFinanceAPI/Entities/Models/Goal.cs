using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Goal
    {
        public Guid GoalId { get; set; }
        public Guid UserId { get; set; }
        public string GoalName { get; set; } = string.Empty;
        public decimal TargetAmount { get; set; }
        public decimal CurrentAmount { get; set; } = 0.0m;
        public DateTime Deadline { get; set; }
        public bool IsAchieved { get; set; } = false;
        public string Description { get; set; } = string.Empty;

        // Navigation properties
        public User User { get; set; }
    }
}
