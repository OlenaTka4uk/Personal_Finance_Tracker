using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Persistense.Interfaces
{
    public interface IRepositoryManager
    {
        IUserRepository User { get;}
        IBudgetRepository Budget { get; }
        IGoalRepository Goal { get; }
        ITransactionRepository Transaction { get; }
        INotificationRepository Notification { get; }
        IReportRepository Report { get; }
        void Save();
    }
}
