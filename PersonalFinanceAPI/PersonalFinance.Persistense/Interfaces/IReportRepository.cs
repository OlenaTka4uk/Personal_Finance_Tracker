﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Persistense.Interfaces
{
    public interface IReportRepository
    {
        IEnumerable<Report> GetAllReportsByUserId(Guid userId);
        Report GetReport(Guid reportId, bool trackChanges);
        void CreateReport(Guid userId, Report report);
        void DeleteReport(Report report);
    }
}
