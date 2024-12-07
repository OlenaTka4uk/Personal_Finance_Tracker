using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PersonalFinance.Persistense.Migrations
{
    /// <inheritdoc />
    public partial class AddCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Budgets_Users_UserId",
                table: "Budgets");

            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Users_UserId",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Users_UserId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_UserId",
                table: "Transactions");

            migrationBuilder.DeleteData(
                table: "Budgets",
                keyColumn: "BudgetId",
                keyValue: new Guid("299c7e42-e613-475a-b369-37b6f2909d49"));

            migrationBuilder.DeleteData(
                table: "Budgets",
                keyColumn: "BudgetId",
                keyValue: new Guid("b7a6044f-5412-4d70-832f-20956946fdd5"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "NotificationId",
                keyValue: new Guid("7a74fff8-cc37-4277-a2a6-d5b5a4aa2256"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "NotificationId",
                keyValue: new Guid("8bb22c49-a077-4164-857c-d8789da113da"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: new Guid("14f416a2-f229-4ace-b191-c83bad467bac"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: new Guid("61d14fd1-6bfa-48ec-be78-62c5ac34e053"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("45609676-3897-44fb-b80a-5b077a51842d"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("ec821cae-c9ea-435c-939a-a0c4947e9c9b"));

            migrationBuilder.InsertData(
                table: "Budgets",
                columns: new[] { "BudgetId", "Amount", "Category", "EndDate", "Spent", "StartDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("844f2d7d-9bff-4f90-8ff3-a80749aef178"), 500.00m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 200.00m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("aa3b08ab-7085-43d9-b91d-2efb90bdc54c"), 300.00m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.00m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11111111-1111-1111-1111-111111111112") }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "NotificationId", "IsRead", "Message", "SentAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("1e535081-327e-4beb-bab6-4ccd851d3d6f"), false, "You reached 50% of your vacation goal!", new DateTime(2024, 12, 7, 11, 17, 18, 917, DateTimeKind.Utc).AddTicks(3694), new Guid("11111111-1111-1111-1111-111111111112") },
                    { new Guid("398cd09d-a267-4fab-b5f0-21abb6bb1cbb"), false, "Your budget for groceries is 80% spent.", new DateTime(2024, 12, 7, 11, 17, 18, 917, DateTimeKind.Utc).AddTicks(3687), new Guid("11111111-1111-1111-1111-111111111111") }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "ReportId", "CreatedAt", "FilePath", "ReportTitle", "ReportType", "UserId" },
                values: new object[,]
                {
                    { new Guid("0f68f904-81fb-4f33-8404-b94e481a20a4"), new DateTime(2024, 12, 7, 11, 17, 18, 917, DateTimeKind.Utc).AddTicks(4983), "/reports/annual-income.xlsx", "Annual Income", 1, new Guid("11111111-1111-1111-1111-111111111112") },
                    { new Guid("f2a309af-b46b-403e-96bb-3f9c29f2982b"), new DateTime(2024, 12, 7, 11, 17, 18, 917, DateTimeKind.Utc).AddTicks(4975), "/reports/monthly-expenses.pdf", "Monthly Expenses", 0, new Guid("11111111-1111-1111-1111-111111111111") }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "Category", "Description", "TransactionDate", "TransactionType", "UserId" },
                values: new object[,]
                {
                    { new Guid("9c24fcfb-0e01-45a7-99f5-2f4e2feb2251"), 2000.00m, 0, "Monthly salary", new DateTime(2024, 12, 7, 11, 17, 18, 917, DateTimeKind.Utc).AddTicks(1422), 0, new Guid("11111111-1111-1111-1111-111111111112") },
                    { new Guid("cb7d6b5c-301b-4001-9096-f23e41e25a06"), 50.00m, 2, "Weekly groceries", new DateTime(2024, 12, 7, 11, 17, 18, 917, DateTimeKind.Utc).AddTicks(1393), 1, new Guid("11111111-1111-1111-1111-111111111111") }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "CreatedAt",
                value: new DateTime(2024, 12, 7, 11, 17, 18, 917, DateTimeKind.Utc).AddTicks(330));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"),
                column: "CreatedAt",
                value: new DateTime(2024, 12, 7, 11, 17, 18, 917, DateTimeKind.Utc).AddTicks(350));

            migrationBuilder.AddForeignKey(
                name: "FK_Budgets_Users_UserId",
                table: "Budgets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Users_UserId",
                table: "Goals",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Users_UserId",
                table: "Reports",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_UserId",
                table: "Transactions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Budgets_Users_UserId",
                table: "Budgets");

            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Users_UserId",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Users_UserId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_UserId",
                table: "Transactions");

            migrationBuilder.DeleteData(
                table: "Budgets",
                keyColumn: "BudgetId",
                keyValue: new Guid("844f2d7d-9bff-4f90-8ff3-a80749aef178"));

            migrationBuilder.DeleteData(
                table: "Budgets",
                keyColumn: "BudgetId",
                keyValue: new Guid("aa3b08ab-7085-43d9-b91d-2efb90bdc54c"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "NotificationId",
                keyValue: new Guid("1e535081-327e-4beb-bab6-4ccd851d3d6f"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "NotificationId",
                keyValue: new Guid("398cd09d-a267-4fab-b5f0-21abb6bb1cbb"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: new Guid("0f68f904-81fb-4f33-8404-b94e481a20a4"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: new Guid("f2a309af-b46b-403e-96bb-3f9c29f2982b"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("9c24fcfb-0e01-45a7-99f5-2f4e2feb2251"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("cb7d6b5c-301b-4001-9096-f23e41e25a06"));

            migrationBuilder.InsertData(
                table: "Budgets",
                columns: new[] { "BudgetId", "Amount", "Category", "EndDate", "Spent", "StartDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("299c7e42-e613-475a-b369-37b6f2909d49"), 500.00m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 200.00m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("b7a6044f-5412-4d70-832f-20956946fdd5"), 300.00m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.00m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11111111-1111-1111-1111-111111111112") }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "NotificationId", "IsRead", "Message", "SentAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("7a74fff8-cc37-4277-a2a6-d5b5a4aa2256"), false, "You reached 50% of your vacation goal!", new DateTime(2024, 11, 23, 16, 7, 45, 438, DateTimeKind.Utc).AddTicks(7643), new Guid("11111111-1111-1111-1111-111111111112") },
                    { new Guid("8bb22c49-a077-4164-857c-d8789da113da"), false, "Your budget for groceries is 80% spent.", new DateTime(2024, 11, 23, 16, 7, 45, 438, DateTimeKind.Utc).AddTicks(7636), new Guid("11111111-1111-1111-1111-111111111111") }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "ReportId", "CreatedAt", "FilePath", "ReportTitle", "ReportType", "UserId" },
                values: new object[,]
                {
                    { new Guid("14f416a2-f229-4ace-b191-c83bad467bac"), new DateTime(2024, 11, 23, 16, 7, 45, 438, DateTimeKind.Utc).AddTicks(8881), "/reports/annual-income.xlsx", "Annual Income", 1, new Guid("11111111-1111-1111-1111-111111111112") },
                    { new Guid("61d14fd1-6bfa-48ec-be78-62c5ac34e053"), new DateTime(2024, 11, 23, 16, 7, 45, 438, DateTimeKind.Utc).AddTicks(8871), "/reports/monthly-expenses.pdf", "Monthly Expenses", 0, new Guid("11111111-1111-1111-1111-111111111111") }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "Category", "Description", "TransactionDate", "TransactionType", "UserId" },
                values: new object[,]
                {
                    { new Guid("45609676-3897-44fb-b80a-5b077a51842d"), 2000.00m, 0, "Monthly salary", new DateTime(2024, 11, 23, 16, 7, 45, 438, DateTimeKind.Utc).AddTicks(5424), 0, new Guid("11111111-1111-1111-1111-111111111112") },
                    { new Guid("ec821cae-c9ea-435c-939a-a0c4947e9c9b"), 50.00m, 2, "Weekly groceries", new DateTime(2024, 11, 23, 16, 7, 45, 438, DateTimeKind.Utc).AddTicks(5396), 1, new Guid("11111111-1111-1111-1111-111111111111") }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "CreatedAt",
                value: new DateTime(2024, 11, 23, 16, 7, 45, 438, DateTimeKind.Utc).AddTicks(4184));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"),
                column: "CreatedAt",
                value: new DateTime(2024, 11, 23, 16, 7, 45, 438, DateTimeKind.Utc).AddTicks(4209));

            migrationBuilder.AddForeignKey(
                name: "FK_Budgets_Users_UserId",
                table: "Budgets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Users_UserId",
                table: "Goals",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Users_UserId",
                table: "Reports",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_UserId",
                table: "Transactions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
