using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinance.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Persistense.Configuration
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(r => r.ReportId);

            builder.Property(r => r.ReportTitle)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(r => r.ReportType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(r => r.FilePath)
                .IsRequired();

            builder.HasOne(r => r.User)
                .WithMany(u => u.Reports)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction);
                

            builder.HasData(
            new Report 
            { ReportId = Guid.NewGuid(), 
                ReportTitle = "Monthly Expenses", 
                ReportType = ReportType.PDF, 
                FilePath = "/reports/monthly-expenses.pdf", 
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111") 
            },
            new Report 
            { 
                ReportId = Guid.NewGuid(), 
                ReportTitle = "Annual Income", 
                ReportType = ReportType.Excel, 
                FilePath = "/reports/annual-income.xlsx", 
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111112") }
        );
        }
    }
}
