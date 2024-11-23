using Entities.Models;
using Microsoft.EntityFrameworkCore;
using PersonalFinance.Persistense.Data;
using PersonalFinance.Persistense.Interfaces;

namespace PersonalFinance.Persistense.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<User> GetAllUsers(bool trackChanges) => FindAll(trackChanges)
            .Include(x => x.Budgets)
            .Include(x => x.Transactions)
            .Include(x => x.Goals)
            .Include(x => x.Notifications)
            .Include(x => x.Reports)
            .OrderBy(c => c.UserLastName)
            .ToList();


    }
}
