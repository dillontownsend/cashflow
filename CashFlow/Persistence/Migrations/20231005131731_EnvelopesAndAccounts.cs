using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CashFlow.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EnvelopesAndAccounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserBudgetProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BudgetStartDayOfMonth = table.Column<int>(type: "integer", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBudgetProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBudgetProfiles_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Envelope",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UserBudgetProfileId = table.Column<int>(type: "integer", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    MonthlyPayment = table.Column<decimal>(type: "numeric", nullable: true),
                    DueDayOfMonth = table.Column<int>(type: "integer", nullable: true),
                    Goal = table.Column<decimal>(type: "numeric", nullable: true),
                    Balance = table.Column<decimal>(type: "numeric", nullable: true),
                    GoalEnvelopeInterval = table.Column<int>(type: "integer", nullable: true),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Amount = table.Column<decimal>(type: "numeric", nullable: true),
                    PrimaryEnvelope_Balance = table.Column<decimal>(type: "numeric", nullable: true),
                    PrimaryEnvelope_DueDayOfMonth = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Envelope", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Envelope_UserBudgetProfiles_UserBudgetProfileId",
                        column: x => x.UserBudgetProfileId,
                        principalTable: "UserBudgetProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Balance = table.Column<decimal>(type: "numeric", nullable: false),
                    UserBudgetProfileId = table.Column<int>(type: "integer", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    DebtPaymentType = table.Column<int>(type: "integer", nullable: true),
                    DebtAccount_DebtPaymentType = table.Column<int>(type: "integer", nullable: true),
                    InterestRate = table.Column<decimal>(type: "numeric", nullable: true),
                    DebtEnvelopeId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_Envelope_DebtEnvelopeId",
                        column: x => x.DebtEnvelopeId,
                        principalTable: "Envelope",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Account_UserBudgetProfiles_UserBudgetProfileId",
                        column: x => x.UserBudgetProfileId,
                        principalTable: "UserBudgetProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_DebtEnvelopeId",
                table: "Account",
                column: "DebtEnvelopeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_UserBudgetProfileId",
                table: "Account",
                column: "UserBudgetProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Envelope_UserBudgetProfileId",
                table: "Envelope",
                column: "UserBudgetProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBudgetProfiles_ApplicationUserId",
                table: "UserBudgetProfiles",
                column: "ApplicationUserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Envelope");

            migrationBuilder.DropTable(
                name: "UserBudgetProfiles");
        }
    }
}
