using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldLoanFinance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeIsPledgedFlagFromLoanMasterToDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPledgedToBank",
                table: "LoanMaster");

            migrationBuilder.AddColumn<bool>(
                name: "IsPledgedToBank",
                table: "LoanDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "LoanDetails",
                keyColumn: "ArticleId",
                keyValue: 1,
                column: "IsPledgedToBank",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPledgedToBank",
                table: "LoanDetails");

            migrationBuilder.AddColumn<bool>(
                name: "IsPledgedToBank",
                table: "LoanMaster",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "LoanMaster",
                keyColumn: "LoanId",
                keyValue: 1,
                column: "IsPledgedToBank",
                value: false);
        }
    }
}
