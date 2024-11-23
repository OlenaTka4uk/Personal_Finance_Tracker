using Entities.Models;
using Microsoft.EntityFrameworkCore;
using PersonalFinance.Persistense.Data;
using PersonalFinance.Persistense.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
            .OrderBy(c => c.Username)
            .ToList();


    }
}
