using PersonalFinance.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.DTO.Report
{
    public class AddReportDTO
    {
        public string ReportTitle { get; set; } = "Monthly Financial Report";
        public ReportType ReportType { get; set; } = ReportType.PDF;
        public string FilePath { get; set; } = string.Empty;
    }
}
