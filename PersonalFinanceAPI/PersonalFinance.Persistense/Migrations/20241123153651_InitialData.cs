using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PersonalFinance.Persistense.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    BudgetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Spent = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.BudgetId);
                    table.ForeignKey(
                        name: "FK_Budgets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    GoalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GoalName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TargetAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CurrentAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAchieved = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.GoalId);
                    table.ForeignKey(
                        name: "FK_Goals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    SentAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReportType = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_Reports_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionType = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Category = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedAt", "Email", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 11, 23, 15, 36, 51, 344, DateTimeKind.Utc).AddTicks(2529), "john.doe@example.com", "hashedpassword1", 1, "John Doe" },
                    { new Guid("11111111-1111-1111-1111-111111111112"), new DateTime(2024, 11, 23, 15, 36, 51, 344, DateTimeKind.Utc).AddTicks(2556), "jane.doe@example.com", "hashedpassword2", 0, "Jane Doe" }
                });

            migrationBuilder.InsertData(
                table: "Budgets",
                columns: new[] { "BudgetId", "Amount", "Category", "EndDate", "Spent", "StartDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("d63cc618-9bcf-4447-94de-2b8030c824d4"), 300.00m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.00m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11111111-1111-1111-1111-111111111112") },
                    { new Guid("d797af25-538c-47eb-8c98-73dbfbb0792e"), 500.00m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 200.00m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11111111-1111-1111-1111-111111111111") }
                });

            migrationBuilder.InsertData(
                table: "Goals",
                columns: new[] { "GoalId", "CurrentAmount", "Deadline", "Description", "GoalName", "IsAchieved", "TargetAmount", "UserId" },
                values: new object[,]
                {
                    { new Guid("66666666-6666-6666-6666-666666666666"), 1000.00m, new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Save for unexpected expenses.", "Emergency Fund", false, 5000.00m, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("77777777-7777-7777-7777-777777777777"), 1500.00m, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Save for a summer vacation.", "Vacation Fund", false, 3000.00m, new Guid("11111111-1111-1111-1111-111111111112") }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "NotificationId", "IsRead", "Message", "SentAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("7e3ac319-e7b6-4652-be9d-1ee25b90cfb1"), false, "You reached 50% of your vacation goal!", new DateTime(2024, 11, 23, 15, 36, 51, 344, DateTimeKind.Utc).AddTicks(7169), new Guid("11111111-1111-1111-1111-111111111112") },
                    { new Guid("ca3c707f-41a2-436c-b9ab-60d85b9f1795"), false, "Your budget for groceries is 80% spent.", new DateTime(2024, 11, 23, 15, 36, 51, 344, DateTimeKind.Utc).AddTicks(7144), new Guid("11111111-1111-1111-1111-111111111111") }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "ReportId", "CreatedAt", "FilePath", "ReportTitle", "ReportType", "UserId" },
                values: new object[,]
                {
                    { new Guid("09aaf444-f462-4277-a806-eefbabfcd3ff"), new DateTime(2024, 11, 23, 15, 36, 51, 344, DateTimeKind.Utc).AddTicks(9591), "/reports/monthly-expenses.pdf", "Monthly Expenses", 0, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("244ba746-f0f0-42fc-a727-b5aaec08d6e7"), new DateTime(2024, 11, 23, 15, 36, 51, 344, DateTimeKind.Utc).AddTicks(9621), "/reports/annual-income.xlsx", "Annual Income", 1, new Guid("11111111-1111-1111-1111-111111111112") }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "Category", "Description", "TransactionDate", "TransactionType", "UserId" },
                values: new object[,]
                {
                    { new Guid("466f2215-48a0-4808-9850-1d1867a111d8"), 2000.00m, 0, "Monthly salary", new DateTime(2024, 11, 23, 15, 36, 51, 344, DateTimeKind.Utc).AddTicks(4229), 0, new Guid("11111111-1111-1111-1111-111111111112") },
                    { new Guid("d6a812c3-5379-420c-94b7-f9669a5ec3a4"), 50.00m, 2, "Weekly groceries", new DateTime(2024, 11, 23, 15, 36, 51, 344, DateTimeKind.Utc).AddTicks(4196), 1, new Guid("11111111-1111-1111-1111-111111111111") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_UserId",
                table: "Budgets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_UserId",
                table: "Goals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_UserId",
                table: "Reports",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
