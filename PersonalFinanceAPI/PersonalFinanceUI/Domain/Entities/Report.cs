using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Report
    {
        public int ReportId { get; set; }
        public int UserId { get; set; }
        public string ReportType { get; set; }
        public string FilePath { get; set; }
        public DateTime GeneratedAt { get; set; }

        //Navigation property
        public User User { get; set; }
    }
}
