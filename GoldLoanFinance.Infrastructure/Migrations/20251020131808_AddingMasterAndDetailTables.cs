using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldLoanFinance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingMasterAndDetailTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Repledges");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.CreateTable(
                name: "LoanMaster",
                columns: table => new
                {
                    LoanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanAmount = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: false),
                    DateTaken = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPledgedToBank = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanMaster", x => x.LoanId);
                    table.ForeignKey(
                        name: "FK_LoanMaster_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepledgeMaster",
                columns: table => new
                {
                    RepledgeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanAmountFromBank = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: false),
                    DatePledged = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepledgeMaster", x => x.RepledgeId);
                    table.ForeignKey(
                        name: "FK_RepledgeMaster_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "BankId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanDetails",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<int>(type: "int", nullable: false),
                    LoanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanDetails", x => x.ArticleId);
                    table.ForeignKey(
                        name: "FK_LoanDetails_LoanMaster_LoanId",
                        column: x => x.LoanId,
                        principalTable: "LoanMaster",
                        principalColumn: "LoanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepledgeDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepledgeId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepledgeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepledgeDetails_LoanDetails_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "LoanDetails",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepledgeDetails_RepledgeMaster_RepledgeId",
                        column: x => x.RepledgeId,
                        principalTable: "RepledgeMaster",
                        principalColumn: "RepledgeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanDetails_LoanId",
                table: "LoanDetails",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanMaster_CustomerId",
                table: "LoanMaster",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_RepledgeDetails_ArticleId",
                table: "RepledgeDetails",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_RepledgeDetails_RepledgeId",
                table: "RepledgeDetails",
                column: "RepledgeId");

            migrationBuilder.CreateIndex(
                name: "IX_RepledgeMaster_BankId",
                table: "RepledgeMaster",
                column: "BankId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepledgeDetails");

            migrationBuilder.DropTable(
                name: "LoanDetails");

            migrationBuilder.DropTable(
                name: "RepledgeMaster");

            migrationBuilder.DropTable(
                name: "LoanMaster");

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppraisedValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WeightInGrams = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ArticleId);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    LoanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    DateTaken = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPledgedToBank = table.Column<bool>(type: "bit", nullable: false),
                    LoanAmount = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.LoanId);
                    table.ForeignKey(
                        name: "FK_Loans_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loans_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Repledges",
                columns: table => new
                {
                    RepledgeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    DatePledged = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoanAmountFromBank = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repledges", x => x.RepledgeId);
                    table.ForeignKey(
                        name: "FK_Repledges_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Repledges_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "BankId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loans_ArticleId",
                table: "Loans",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_CustomerId",
                table: "Loans",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Repledges_ArticleId",
                table: "Repledges",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Repledges_BankId",
                table: "Repledges",
                column: "BankId");
        }
    }
}
