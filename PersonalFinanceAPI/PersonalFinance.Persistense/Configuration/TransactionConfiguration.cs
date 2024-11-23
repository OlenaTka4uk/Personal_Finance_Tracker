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
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(t => t.TransactionId); // Primary Key

            builder.Property(t => t.TransactionType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.Category)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.Amount)
                .HasPrecision(18, 2);

            builder.Property(t => t.Description)
                .HasMaxLength(200);

            builder.HasOne(t => t.User)
                .WithMany(u => u.Transactions)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.NoAction);

           builder.HasData(
            new Transaction 
            { 
                TransactionId = Guid.NewGuid(), 
                TransactionType = TransactionType.Expense, 
                Category = TransactionCategory.Groceries, 
                Amount = 50.00M, 
                Description = "Weekly groceries", 
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111") 
            },
            new Transaction 
            { 
                TransactionId = Guid.NewGuid(), 
                TransactionType = TransactionType.Income, 
                Category = TransactionCategory.Salary, 
                Amount = 2000.00M, 
                Description = "Monthly salary", 
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111112") 
            }
        );
        }
    }
}
