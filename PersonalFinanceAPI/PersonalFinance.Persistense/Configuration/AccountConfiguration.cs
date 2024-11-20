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
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.AccountId);

            builder.Property(a => a.AccountName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.AccountType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.CurrentBalance)
                .HasPrecision(18, 2);

            builder.Property(a => a.Currency)
                .IsRequired()
                .HasMaxLength(3); // e.g., USD

            builder.HasOne(a => a.User)
                .WithMany(u => u.Accounts)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(a => a.Transactions)
                .WithOne(t => t.Account)
                .HasForeignKey(t => t.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
            new Account 
            { 
                AccountId = Guid.Parse("11111111-1111-1111-1111-111111111113"), 
                AccountName = "Savings Account", 
                AccountType = AccountType.Bank, 
                CurrentBalance = 1000.00M, 
                Currency = Currency.USD, 
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new Account 
            { 
                AccountId = Guid.Parse("11111111-1111-1111-1111-111111111114"), 
                AccountName = "Checking Account", 
                AccountType = AccountType.Bank, 
                CurrentBalance = 500.00M, 
                Currency = Currency.USD, 
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111112") 
            }
        );
        }
    }
}
