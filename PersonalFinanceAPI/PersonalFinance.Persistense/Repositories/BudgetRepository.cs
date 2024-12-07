using Entities.Models;
using PersonalFinance.Persistense.Data;
using PersonalFinance.Persistense.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Persistense.Repositories
{
    public class BudgetRepository : RepositoryBase<Budget>, IBudgetRepository
    {
        public BudgetRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public void CreateBudget(Guid userId, Budget budget)
        {
            budget.UserId = userId;
            Create(budget);
        }

        public void DeleteBudget(Budget budget) => Delete(budget);
        
        public IEnumerable<Budget> GetAllBudgetsByUserId(Guid userId) => FindByCondition(x => x.UserId == userId, false)
            .ToList();

        public IEnumerable<Budget> GetAllBudgetsByUserName(string userFirstName, string userLastName) => FindByCondition(x => x.User.UserLastName == userLastName
            && x.User.UserFirstName == userFirstName, false).ToList();

        public Budget GetBudget(Guid budgetId, bool trackChanges) => FindByCondition(c => c.BudgetId.Equals(budgetId), trackChanges)
            .SingleOrDefault();

    }
}
