using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GoldLoanFinance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class reInitiatingEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "Loans",
                newName: "CustomerId");

            migrationBuilder.AddColumn<int>(
                name: "ArticleId",
                table: "Repledges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePledged",
                table: "Repledges",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "LoanAmountFromBank",
                table: "Repledges",
                type: "decimal(15,5)",
                precision: 15,
                scale: 5,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTaken",
                table: "Loans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Loans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsPledgedToBank",
                table: "Loans",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "LoanAmount",
                table: "Loans",
                type: "decimal(15,5)",
                precision: 15,
                scale: 5,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NIC",
                table: "Customers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Customers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Banks",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AppraisedValue",
                table: "Articles",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Articles",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "WeightInGrams",
                table: "Articles",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Repledges_ArticleId",
                table: "Repledges",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Repledges_BankId",
                table: "Repledges",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_ArticleId",
                table: "Loans",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_CustomerId",
                table: "Loans",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Articles_ArticleId",
                table: "Loans",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "ArticleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Customers_CustomerId",
                table: "Loans",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Repledges_Articles_ArticleId",
                table: "Repledges",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "ArticleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Repledges_Banks_BankId",
                table: "Repledges",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "BankId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Articles_ArticleId",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Customers_CustomerId",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Repledges_Articles_ArticleId",
                table: "Repledges");

            migrationBuilder.DropForeignKey(
                name: "FK_Repledges_Banks_BankId",
                table: "Repledges");

            migrationBuilder.DropIndex(
                name: "IX_Repledges_ArticleId",
                table: "Repledges");

            migrationBuilder.DropIndex(
                name: "IX_Repledges_BankId",
                table: "Repledges");

            migrationBuilder.DropIndex(
                name: "IX_Loans_ArticleId",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_CustomerId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "Repledges");

            migrationBuilder.DropColumn(
                name: "DatePledged",
                table: "Repledges");

            migrationBuilder.DropColumn(
                name: "LoanAmountFromBank",
                table: "Repledges");

            migrationBuilder.DropColumn(
                name: "DateTaken",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "IsPledgedToBank",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "LoanAmount",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "NIC",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AppraisedValue",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "WeightInGrams",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Loans",
                newName: "Unit");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Banks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleId", "Name" },
                values: new object[,]
                {
                    { 1, "Necklace" },
                    { 2, "Ring" },
                    { 3, "Bracelet" }
                });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "BankId", "Name" },
                values: new object[] { 1, "ABC" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "Name" },
                values: new object[,]
                {
                    { 1, "No50, ABCD Road, Colombo", "Prashath" },
                    { 2, "No50, ABCD Road, Colombo", "Ranmini" }
                });
        }
    }
}
