﻿using Entities.Models;
using PersonalFinance.Persistense.Data;
using PersonalFinance.Persistense.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Persistense.Repositories
{
    public class GoalRepository : RepositoryBase<Goal>, IGoalRepository
    {
        public GoalRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Goal> GetAllGoalsByAchievement(bool isAchieved) => FindByCondition(x => x.IsAchieved == isAchieved, false)
            .ToList();


        public IEnumerable<Goal> GetAllGoalsByDeadline(DateTime deadline) => FindByCondition(x => x.Deadline == deadline, false)
            .ToList();
        

        public IEnumerable<Goal> GetAllGoalsByUserId(Guid userId) => FindByCondition(x => x.UserId == userId, false)
            .ToList();

    }
}
