using PersonalFinance.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.DTO.Report
{
    public class ReportDTO
    {
        public Guid ReportId { get; set; }
        public Guid UserId { get; set; }
        public string ReportTitle { get; set; } = "Monthly Financial Report";
        public ReportType ReportType { get; set; } = ReportType.PDF;
        public string FilePath { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
