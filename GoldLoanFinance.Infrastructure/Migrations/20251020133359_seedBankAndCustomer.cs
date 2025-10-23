using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GoldLoanFinance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedBankAndCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "BankId", "Name" },
                values: new object[,]
                {
                    { 1, "HNB" },
                    { 2, "ABC" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "NIC", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "856987452v", "Prashath", "0715689562" },
                    { 2, "895698236v", "Ranmini", "0715458533" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "BankId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);
        }
    }
}
