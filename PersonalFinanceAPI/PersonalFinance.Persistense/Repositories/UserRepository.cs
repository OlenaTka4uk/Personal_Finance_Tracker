using Entities.Models;
using Microsoft.EntityFrameworkCore;
using PersonalFinance.Persistense.Data;
using PersonalFinance.Persistense.Interfaces;
using System.ComponentModel.Design;

namespace PersonalFinance.Persistense.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)  {}

        public IEnumerable<User> GetAllUsers(bool trackChanges) => FindAll(trackChanges)
            .Include(x => x.Budgets)
            .Include(x => x.Transactions)
            .Include(x => x.Goals)
            .Include(x => x.Notifications)
            .Include(x => x.Reports)
            .OrderBy(c => c.UserLastName)
        .ToList();

        public User GetUser(Guid id, bool trackChanges) => 
            FindByCondition(c => c.UserId.Equals(id), trackChanges)
            .SingleOrDefault();

        public User GetUserByFullName(string firstName, string lastName, bool trackChanges) =>
            FindByCondition(x => x.UserFirstName.Equals(firstName) && x.UserLastName.Equals(lastName), false)   
            .SingleOrDefault();

        public void CreateUser(User user) => Create(user);

        public void DeleteUser(User user) => Delete(user);
        
    }
}
