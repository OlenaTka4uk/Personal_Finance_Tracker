using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PersonalFinance.Persistense.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers(bool trackChanges);  
        User GetUser(Guid id, bool trackChanges);
        User GetUserByFullName(string firstName, string lastName, bool trackChanges);
        void CreateUser (User user);
        void DeleteUser (User user);          

    }
}
