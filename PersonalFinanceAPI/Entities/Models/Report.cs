﻿using PersonalFinance.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Report
    {
        public Guid ReportId { get; set; }
        public Guid UserId { get; set; }
        public string ReportTitle { get; set; } = "Monthly Financial Report";
        public ReportType ReportType { get; set; } = ReportType.PDF;
        public string FilePath { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public User User { get; set; }
    }
}