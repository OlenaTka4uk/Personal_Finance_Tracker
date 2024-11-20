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
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(n => n.NotificationId); // Primary Key

            builder.Property(n => n.Message)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(n => n.IsRead)
                .IsRequired();

            builder.HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
            new Notification 
            { NotificationId = Guid.NewGuid(), 
                Message = "Your budget for groceries is 80% spent.", 
                IsRead = false, 
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111") 
            },
            new Notification 
            { 
                NotificationId = Guid.NewGuid(), 
                Message = "You reached 50% of your vacation goal!", 
                IsRead = false, 
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111112") }
        );
        }
    }
}
