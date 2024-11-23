using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Persistense.Interfaces
{
    public interface IGoalRepository
    {
        IEnumerable<Goal> GetAllGoalsByUserId(Guid userId);
    }
}
