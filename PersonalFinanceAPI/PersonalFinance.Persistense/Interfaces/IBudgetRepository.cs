using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Persistense.Interfaces
{
    public interface IBudgetRepository
    {
        IEnumerable<Budget> GetAllBudgetsByUserId(Guid userId);
        IEnumerable<Budget> GetAllBudgetsByUserName(string userFirstName, string userLastName);
        Budget GetBudget(Guid budgetId, bool trackChanges);
        void CreateBudget(Guid userId, Budget budget);
        void DeleteBudget(Budget budget);
    }
}
