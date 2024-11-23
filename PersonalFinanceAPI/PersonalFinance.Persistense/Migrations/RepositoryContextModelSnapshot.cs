﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonalFinance.Persistense.Data;

#nullable disable

namespace PersonalFinance.Persistense.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Models.Budget", b =>
                {
                    b.Property<Guid>("BudgetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Category")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Spent")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BudgetId");

                    b.HasIndex("UserId");

                    b.ToTable("Budgets");

                    b.HasData(
                        new
                        {
                            BudgetId = new Guid("299c7e42-e613-475a-b369-37b6f2909d49"),
                            Amount = 500.00m,
                            Category = 0,
                            EndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Spent = 200.00m,
                            StartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("11111111-1111-1111-1111-111111111111")
                        },
                        new
                        {
                            BudgetId = new Guid("b7a6044f-5412-4d70-832f-20956946fdd5"),
                            Amount = 300.00m,
                            Category = 0,
                            EndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Spent = 50.00m,
                            StartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("11111111-1111-1111-1111-111111111112")
                        });
                });

            modelBuilder.Entity("Entities.Models.Goal", b =>
                {
                    b.Property<Guid>("GoalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("CurrentAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GoalName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsAchieved")
                        .HasColumnType("bit");

                    b.Property<decimal>("TargetAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GoalId");

                    b.HasIndex("UserId");

                    b.ToTable("Goals");

                    b.HasData(
                        new
                        {
                            GoalId = new Guid("66666666-6666-6666-6666-666666666666"),
                            CurrentAmount = 1000.00m,
                            Deadline = new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Save for unexpected expenses.",
                            GoalName = "Emergency Fund",
                            IsAchieved = false,
                            TargetAmount = 5000.00m,
                            UserId = new Guid("11111111-1111-1111-1111-111111111111")
                        },
                        new
                        {
                            GoalId = new Guid("77777777-7777-7777-7777-777777777777"),
                            CurrentAmount = 1500.00m,
                            Deadline = new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Save for a summer vacation.",
                            GoalName = "Vacation Fund",
                            IsAchieved = false,
                            TargetAmount = 3000.00m,
                            UserId = new Guid("11111111-1111-1111-1111-111111111112")
                        });
                });

            modelBuilder.Entity("Entities.Models.Notification", b =>
                {
                    b.Property<Guid>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("SentAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("NotificationId");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");

                    b.HasData(
                        new
                        {
                            NotificationId = new Guid("8bb22c49-a077-4164-857c-d8789da113da"),
                            IsRead = false,
                            Message = "Your budget for groceries is 80% spent.",
                            SentAt = new DateTime(2024, 11, 23, 16, 7, 45, 438, DateTimeKind.Utc).AddTicks(7636),
                            UserId = new Guid("11111111-1111-1111-1111-111111111111")
                        },
                        new
                        {
                            NotificationId = new Guid("7a74fff8-cc37-4277-a2a6-d5b5a4aa2256"),
                            IsRead = false,
                            Message = "You reached 50% of your vacation goal!",
                            SentAt = new DateTime(2024, 11, 23, 16, 7, 45, 438, DateTimeKind.Utc).AddTicks(7643),
                            UserId = new Guid("11111111-1111-1111-1111-111111111112")
                        });
                });

            modelBuilder.Entity("Entities.Models.Report", b =>
                {
                    b.Property<Guid>("ReportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReportTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ReportType")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ReportId");

                    b.HasIndex("UserId");

                    b.ToTable("Reports");

                    b.HasData(
                        new
                        {
                            ReportId = new Guid("61d14fd1-6bfa-48ec-be78-62c5ac34e053"),
                            CreatedAt = new DateTime(2024, 11, 23, 16, 7, 45, 438, DateTimeKind.Utc).AddTicks(8871),
                            FilePath = "/reports/monthly-expenses.pdf",
                            ReportTitle = "Monthly Expenses",
                            ReportType = 0,
                            UserId = new Guid("11111111-1111-1111-1111-111111111111")
                        },
                        new
                        {
                            ReportId = new Guid("14f416a2-f229-4ace-b191-c83bad467bac"),
                            CreatedAt = new DateTime(2024, 11, 23, 16, 7, 45, 438, DateTimeKind.Utc).AddTicks(8881),
                            FilePath = "/reports/annual-income.xlsx",
                            ReportTitle = "Annual Income",
                            ReportType = 1,
                            UserId = new Guid("11111111-1111-1111-1111-111111111112")
                        });
                });

            modelBuilder.Entity("Entities.Models.Transaction", b =>
                {
                    b.Property<Guid>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Category")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TransactionType")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TransactionId");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            TransactionId = new Guid("ec821cae-c9ea-435c-939a-a0c4947e9c9b"),
                            Amount = 50.00m,
                            Category = 2,
                            Description = "Weekly groceries",
                            TransactionDate = new DateTime(2024, 11, 23, 16, 7, 45, 438, DateTimeKind.Utc).AddTicks(5396),
                            TransactionType = 1,
                            UserId = new Guid("11111111-1111-1111-1111-111111111111")
                        },
                        new
                        {
                            TransactionId = new Guid("45609676-3897-44fb-b80a-5b077a51842d"),
                            Amount = 2000.00m,
                            Category = 0,
                            Description = "Monthly salary",
                            TransactionDate = new DateTime(2024, 11, 23, 16, 7, 45, 438, DateTimeKind.Utc).AddTicks(5424),
                            TransactionType = 0,
                            UserId = new Guid("11111111-1111-1111-1111-111111111112")
                        });
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserFirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserLastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("11111111-1111-1111-1111-111111111111"),
                            CreatedAt = new DateTime(2024, 11, 23, 16, 7, 45, 438, DateTimeKind.Utc).AddTicks(4184),
                            Email = "john.doe@example.com",
                            PasswordHash = "hashedpassword1",
                            Role = 1,
                            UserFirstName = "John",
                            UserLastName = "Doe"
                        },
                        new
                        {
                            UserId = new Guid("11111111-1111-1111-1111-111111111112"),
                            CreatedAt = new DateTime(2024, 11, 23, 16, 7, 45, 438, DateTimeKind.Utc).AddTicks(4209),
                            Email = "jane.doe@example.com",
                            PasswordHash = "hashedpassword2",
                            Role = 0,
                            UserFirstName = "Jane",
                            UserLastName = "Doe"
                        });
                });

            modelBuilder.Entity("Entities.Models.Budget", b =>
                {
                    b.HasOne("Entities.Models.User", "User")
                        .WithMany("Budgets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Models.Goal", b =>
                {
                    b.HasOne("Entities.Models.User", "User")
                        .WithMany("Goals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Models.Notification", b =>
                {
                    b.HasOne("Entities.Models.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Models.Report", b =>
                {
                    b.HasOne("Entities.Models.User", "User")
                        .WithMany("Reports")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Models.Transaction", b =>
                {
                    b.HasOne("Entities.Models.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.Navigation("Budgets");

                    b.Navigation("Goals");

                    b.Navigation("Notifications");

                    b.Navigation("Reports");

                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
