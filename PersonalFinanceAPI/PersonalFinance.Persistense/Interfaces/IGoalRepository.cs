using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Persistense.Interfaces
{
    public interface IGoalRepository
    {
        IEnumerable<Goal> GetAllGoalsByUserId(Guid userId);
        IEnumerable<Goal> GetAllGoalsByDeadline(DateTime deadline);
        IEnumerable<Goal> GetAllGoalsByAchievement(bool isAchieved);
        Goal GetGoal(Guid goalId, bool trackChanges);
        void CreateGoal(Guid userId, Goal goal);
        void DeleteGoal(Goal goal);
    }
}
