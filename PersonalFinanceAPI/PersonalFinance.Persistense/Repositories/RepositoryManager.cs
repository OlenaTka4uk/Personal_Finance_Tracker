using PersonalFinance.Persistense.Data;
using PersonalFinance.Persistense.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Persistense.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private IUserRepository _userRepository;
        private ITransactionRepository _transactionRepository;
        private IBudgetRepository _budgetRepository;
        private IGoalRepository _goalRepository;
        private INotificationRepository _notificationRepository;
        private IReportRepository _reportRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public IUserRepository User
        {
            get 
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_repositoryContext);
                }
                return _userRepository;
            }
        }

        

        public IBudgetRepository Budget
        {
            get
            {
                if (_budgetRepository == null)
                {
                    _budgetRepository= new BudgetRepository(_repositoryContext);
                }
                return _budgetRepository;
            }
        }

        public IGoalRepository Goal
        { 
            get 
            { 
                if (_goalRepository == null)
                {
                    _goalRepository= new GoalRepository(_repositoryContext);
                }
                return _goalRepository;
            } 
        } 

        public ITransactionRepository Transaction
        {
            get
            {
                if (_transactionRepository == null)
                {
                    _transactionRepository= new TransactionRepository(_repositoryContext);
                }
                return _transactionRepository;
            }
        }

        public INotificationRepository Notification
        {
            get
            {
                if (_notificationRepository == null)
                {
                    _notificationRepository = new NotificationRepository(_repositoryContext);
                }
                return _notificationRepository;
            }
        }


        public IReportRepository Report
        {
            get
            {
                if (_reportRepository == null)
                {
                    _reportRepository = new ReportRepository(_repositoryContext);
                }
                return _reportRepository;
            }
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
