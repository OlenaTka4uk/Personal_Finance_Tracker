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
    public class BudgetConfiguration : IEntityTypeConfiguration<Budget>
    {
        public void Configure(EntityTypeBuilder<Budget> builder)
        {
            builder.HasKey(b => b.BudgetId); // Primary Key

            builder.Property(b => b.Category)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(b => b.Amount)
                .HasPrecision(18, 2);

            builder.Property(b => b.Spent)
                .HasPrecision(18, 2);

            builder.HasOne(b => b.User)
                .WithMany(u => u.Budgets)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
            new Budget 
            { 
                BudgetId = Guid.NewGuid(), 
                Category = BudgetCategory.Savings,
                Amount = 500.00M, 
                Spent = 200.00M, 
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111") 
            },
            new Budget 
            { BudgetId = Guid.NewGuid(), 
                Category = BudgetCategory.Savings, 
                Amount = 300.00M, 
                Spent = 50.00M, 
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111112") }
        );
        }
    }
}
