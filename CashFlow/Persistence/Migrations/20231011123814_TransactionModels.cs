using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CashFlow.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TransactionModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExpenseOrCreditTransactionId",
                table: "Envelope",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AccountTransferTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FromAccountId = table.Column<int>(type: "integer", nullable: false),
                    ToAccountId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    ScheduledTransactionInterval = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTransferTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountTransferTransactions_Account_FromAccountId",
                        column: x => x.FromAccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountTransferTransactions_Account_ToAccountId",
                        column: x => x.ToAccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DebtTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Principal = table.Column<decimal>(type: "numeric", nullable: false),
                    Interest = table.Column<decimal>(type: "numeric", nullable: false),
                    Fees = table.Column<decimal>(type: "numeric", nullable: false),
                    DebtAccountId = table.Column<int>(type: "integer", nullable: false),
                    AssetAccountId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    ScheduledTransactionInterval = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebtTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DebtTransaction_Account_AssetAccountId",
                        column: x => x.AssetAccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DebtTransaction_Account_DebtAccountId",
                        column: x => x.DebtAccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnvelopeTransferTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FromEnvelopeId = table.Column<int>(type: "integer", nullable: false),
                    ToEnvelopeId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    ScheduledTransactionInterval = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnvelopeTransferTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnvelopeTransferTransactions_Envelope_FromEnvelopeId",
                        column: x => x.FromEnvelopeId,
                        principalTable: "Envelope",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EnvelopeTransferTransactions_Envelope_ToEnvelopeId",
                        column: x => x.ToEnvelopeId,
                        principalTable: "Envelope",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseOrCreditTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EnvelopeId = table.Column<int>(type: "integer", nullable: false),
                    AccountId = table.Column<int>(type: "integer", nullable: false),
                    AssetAccountId = table.Column<int>(type: "integer", nullable: true),
                    CreditCardAccountId = table.Column<int>(type: "integer", nullable: true),
                    GoalEnvelopeId = table.Column<int>(type: "integer", nullable: true),
                    PrimaryEnvelopeId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    ScheduledTransactionInterval = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseOrCreditTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseOrCreditTransactions_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpenseOrCreditTransactions_Account_AssetAccountId",
                        column: x => x.AssetAccountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExpenseOrCreditTransactions_Account_CreditCardAccountId",
                        column: x => x.CreditCardAccountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExpenseOrCreditTransactions_Envelope_GoalEnvelopeId",
                        column: x => x.GoalEnvelopeId,
                        principalTable: "Envelope",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExpenseOrCreditTransactions_Envelope_PrimaryEnvelopeId",
                        column: x => x.PrimaryEnvelopeId,
                        principalTable: "Envelope",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IncomeTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountId = table.Column<int>(type: "integer", nullable: false),
                    AssetAccountId = table.Column<int>(type: "integer", nullable: true),
                    CreditCardAccountId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    ScheduledTransactionInterval = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomeTransaction_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IncomeTransaction_Account_AssetAccountId",
                        column: x => x.AssetAccountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IncomeTransaction_Account_CreditCardAccountId",
                        column: x => x.CreditCardAccountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Envelope_ExpenseOrCreditTransactionId",
                table: "Envelope",
                column: "ExpenseOrCreditTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransferTransactions_FromAccountId",
                table: "AccountTransferTransactions",
                column: "FromAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransferTransactions_ToAccountId",
                table: "AccountTransferTransactions",
                column: "ToAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_DebtTransaction_AssetAccountId",
                table: "DebtTransaction",
                column: "AssetAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_DebtTransaction_DebtAccountId",
                table: "DebtTransaction",
                column: "DebtAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_EnvelopeTransferTransactions_FromEnvelopeId",
                table: "EnvelopeTransferTransactions",
                column: "FromEnvelopeId");

            migrationBuilder.CreateIndex(
                name: "IX_EnvelopeTransferTransactions_ToEnvelopeId",
                table: "EnvelopeTransferTransactions",
                column: "ToEnvelopeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseOrCreditTransactions_AccountId",
                table: "ExpenseOrCreditTransactions",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseOrCreditTransactions_AssetAccountId",
                table: "ExpenseOrCreditTransactions",
                column: "AssetAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseOrCreditTransactions_CreditCardAccountId",
                table: "ExpenseOrCreditTransactions",
                column: "CreditCardAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseOrCreditTransactions_GoalEnvelopeId",
                table: "ExpenseOrCreditTransactions",
                column: "GoalEnvelopeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseOrCreditTransactions_PrimaryEnvelopeId",
                table: "ExpenseOrCreditTransactions",
                column: "PrimaryEnvelopeId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeTransaction_AccountId",
                table: "IncomeTransaction",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeTransaction_AssetAccountId",
                table: "IncomeTransaction",
                column: "AssetAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeTransaction_CreditCardAccountId",
                table: "IncomeTransaction",
                column: "CreditCardAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Envelope_ExpenseOrCreditTransactions_ExpenseOrCreditTransac~",
                table: "Envelope",
                column: "ExpenseOrCreditTransactionId",
                principalTable: "ExpenseOrCreditTransactions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Envelope_ExpenseOrCreditTransactions_ExpenseOrCreditTransac~",
                table: "Envelope");

            migrationBuilder.DropTable(
                name: "AccountTransferTransactions");

            migrationBuilder.DropTable(
                name: "DebtTransaction");

            migrationBuilder.DropTable(
                name: "EnvelopeTransferTransactions");

            migrationBuilder.DropTable(
                name: "ExpenseOrCreditTransactions");

            migrationBuilder.DropTable(
                name: "IncomeTransaction");

            migrationBuilder.DropIndex(
                name: "IX_Envelope_ExpenseOrCreditTransactionId",
                table: "Envelope");

            migrationBuilder.DropColumn(
                name: "ExpenseOrCreditTransactionId",
                table: "Envelope");
        }
    }
}
