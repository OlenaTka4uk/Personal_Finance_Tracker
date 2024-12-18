﻿using Entities.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
    public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
    {
        public TransactionRepository(RepositoryContext repositoryContext) : base(repositoryContext)  {}

        
        public void CreateTransaction(Guid UserId, Transaction transaction)
        {
            transaction.UserId = UserId;
            Create(transaction);
        }

        public void DeleteTransaction(Transaction transaction) => Delete(transaction);
        

        public IEnumerable<Transaction> GetAllTransaction(Guid id) => FindByCondition(x => x.UserId == id, false)
            .ToList();

        public IEnumerable<Transaction> GetAllTransactionsByUserAndDate(Guid userId, DateTime transactionDate, bool trackChanges) =>
            FindByCondition(x => x.UserId.Equals(userId) && x.TransactionDate.Equals(transactionDate), false)
            .ToList();
        

        public IEnumerable<Transaction> GetAllTransactionsByUserName(string userFirstname, string userLastName) => FindByCondition(x => x.User.UserLastName == userLastName
             && x.User.UserFirstName == userFirstname, false).ToList();

        public Transaction GetTransaction(Guid transactionId, bool trackChanges) =>
            FindByCondition(c => c.TransactionId.Equals(transactionId), trackChanges)
            .SingleOrDefault();

    }
}
