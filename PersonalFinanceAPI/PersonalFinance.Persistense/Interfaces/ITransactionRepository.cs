using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Persistense.Interfaces
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> GetAllTransaction(Guid id);
        IEnumerable<Transaction> GetAllTransactionsByUserName(string userFirstname, string userLastName);       
        IEnumerable<Transaction> GetAllTransactionsByUserAndDate(Guid userId, DateTime transactionDate, bool trackChanges);
        Transaction GetTransaction(Guid transactionId, bool trackChanges);
        void CreateTransaction(Guid UserId, Transaction transaction);
        void DeleteTransaction(Transaction transaction);
    }
}
