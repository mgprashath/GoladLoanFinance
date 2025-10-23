using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldLoanFinance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class keyReferenceCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Unit",
                table: "LoanDetails",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "LoanDetails",
                keyColumn: "ArticleId",
                keyValue: 1,
                column: "Unit",
                value: 1L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Unit",
                table: "LoanDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "LoanDetails",
                keyColumn: "ArticleId",
                keyValue: 1,
                column: "Unit",
                value: 1);
        }
    }
}
