using Entities.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonalFinance.Persistense.Data;
using PersonalFinance.Persistense.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Persistense.Repositories
{
    public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
    {
        public TransactionRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Transaction> GetAllTransaction(Guid id) => FindByCondition(x => x.UserId == id, false)
            .ToList();
        
    }
}
