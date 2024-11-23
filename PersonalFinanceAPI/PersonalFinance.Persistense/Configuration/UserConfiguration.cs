using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinance.Domain.Enum;

namespace PersonalFinance.Persistense.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserId);

            builder.Property(u => u.UserFirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.UserLastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.PasswordHash)
                .IsRequired();

            builder.HasMany(u => u.Transactions)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(u => u.Budgets)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(u => u.Goals)
                .WithOne(g => g.User)
                .HasForeignKey(g => g.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(u => u.Notifications)
                .WithOne(n => n.User)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasData(
            new User 
            { 
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111111"), 
                UserFirstName = "John", 
                UserLastName = "Doe",
                Email = "john.doe@example.com", 
                PasswordHash = "hashedpassword1", 
                Role = Role.User 
            },
            new User 
            { 
                UserId = Guid.Parse("11111111-1111-1111-1111-111111111112"), 
                UserFirstName = "Jane",
                UserLastName =  "Doe",
                Email = "jane.doe@example.com", 
                PasswordHash = "hashedpassword2", 
                Role = Role.Admin 
            }
        );
        }
    }
}
