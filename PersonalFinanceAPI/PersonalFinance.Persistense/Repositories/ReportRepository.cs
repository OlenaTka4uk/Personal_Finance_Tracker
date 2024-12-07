using Entities.Models;
using PersonalFinance.Persistense.Data;
using PersonalFinance.Persistense.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Persistense.Repositories
{
    public class ReportRepository : RepositoryBase<Report>, IReportRepository
    {
        public ReportRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public void CreateReport(Guid userId, Report report)
        {
            report.UserId = userId;
            Create(report);
        }

        public void DeleteReport(Report report) => Delete(report);
       

        public IEnumerable<Report> GetAllReportsByUserId(Guid userId) => FindByCondition(x => x.UserId == userId, false)
            .ToList();

        public Report GetReport(Guid reportId, bool trackChanges) => FindByCondition(c => c.ReportId.Equals(reportId), trackChanges)
            .SingleOrDefault();

    }
}
