using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldLoanFinance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedLoanTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                table: "LoanMaster",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "DATEADD(year,1,GETDATE())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTaken",
                table: "LoanMaster",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "LoanMaster",
                columns: new[] { "LoanId", "CustomerId", "DateTaken", "DueDate", "IsPledgedToBank", "LoanAmount" },
                values: new object[] { 1, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 150.00m });

            migrationBuilder.InsertData(
                table: "LoanDetails",
                columns: new[] { "ArticleId", "ArticleName", "LoanId", "Unit" },
                values: new object[] { 1, "Ring", 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LoanDetails",
                keyColumn: "ArticleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LoanMaster",
                keyColumn: "LoanId",
                keyValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                table: "LoanMaster",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "DATEADD(year,1,GETDATE())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTaken",
                table: "LoanMaster",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
