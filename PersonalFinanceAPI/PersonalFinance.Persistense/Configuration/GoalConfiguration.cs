using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Persistense.Configuration
{
    public class GoalConfiguration : IEntityTypeConfiguration<Goal>
    {
        public void Configure(EntityTypeBuilder<Goal> builder)
        {
            builder.HasKey(g => g.GoalId); // Primary Key

            builder.Property(g => g.GoalName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(g => g.TargetAmount)
                .HasPrecision(18, 2);

            builder.Property(g => g.CurrentAmount)
                .HasPrecision(18, 2);

            builder.HasOne(g => g.User)
                .WithMany(u => u.Goals)
                .HasForeignKey(g => g.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
            new Goal
            {
                GoalId = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                GoalName = "Emergency Fund",
                TargetAmount = 5000.00M,
                CurrentAmount = 1000.00M,
                Deadline = new DateTime(2025, 12, 31),
                IsAchieved = false,
                Description = "Save for unexpected expenses."
            },
            new Goal
            {
                GoalId = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                GoalName = "Vacation Fund",
                TargetAmount = 3000.00M,
                CurrentAmount = 1500.00M,
                Deadline = new DateTime(2024, 6, 1),
                IsAchieved = false,
                Description = "Save for a summer vacation."
            }
        );
        }
    }
}
