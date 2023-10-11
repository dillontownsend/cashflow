using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashFlow.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class OopsTransactionModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DebtTransaction_Account_AssetAccountId",
                table: "DebtTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_DebtTransaction_Account_DebtAccountId",
                table: "DebtTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeTransaction_Account_AccountId",
                table: "IncomeTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeTransaction_Account_AssetAccountId",
                table: "IncomeTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeTransaction_Account_CreditCardAccountId",
                table: "IncomeTransaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IncomeTransaction",
                table: "IncomeTransaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DebtTransaction",
                table: "DebtTransaction");

            migrationBuilder.RenameTable(
                name: "IncomeTransaction",
                newName: "IncomeTransactions");

            migrationBuilder.RenameTable(
                name: "DebtTransaction",
                newName: "DebtTransactions");

            migrationBuilder.RenameIndex(
                name: "IX_IncomeTransaction_CreditCardAccountId",
                table: "IncomeTransactions",
                newName: "IX_IncomeTransactions_CreditCardAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_IncomeTransaction_AssetAccountId",
                table: "IncomeTransactions",
                newName: "IX_IncomeTransactions_AssetAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_IncomeTransaction_AccountId",
                table: "IncomeTransactions",
                newName: "IX_IncomeTransactions_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_DebtTransaction_DebtAccountId",
                table: "DebtTransactions",
                newName: "IX_DebtTransactions_DebtAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_DebtTransaction_AssetAccountId",
                table: "DebtTransactions",
                newName: "IX_DebtTransactions_AssetAccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IncomeTransactions",
                table: "IncomeTransactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DebtTransactions",
                table: "DebtTransactions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DebtTransactions_Account_AssetAccountId",
                table: "DebtTransactions",
                column: "AssetAccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DebtTransactions_Account_DebtAccountId",
                table: "DebtTransactions",
                column: "DebtAccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeTransactions_Account_AccountId",
                table: "IncomeTransactions",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeTransactions_Account_AssetAccountId",
                table: "IncomeTransactions",
                column: "AssetAccountId",
                principalTable: "Account",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeTransactions_Account_CreditCardAccountId",
                table: "IncomeTransactions",
                column: "CreditCardAccountId",
                principalTable: "Account",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DebtTransactions_Account_AssetAccountId",
                table: "DebtTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_DebtTransactions_Account_DebtAccountId",
                table: "DebtTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeTransactions_Account_AccountId",
                table: "IncomeTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeTransactions_Account_AssetAccountId",
                table: "IncomeTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeTransactions_Account_CreditCardAccountId",
                table: "IncomeTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IncomeTransactions",
                table: "IncomeTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DebtTransactions",
                table: "DebtTransactions");

            migrationBuilder.RenameTable(
                name: "IncomeTransactions",
                newName: "IncomeTransaction");

            migrationBuilder.RenameTable(
                name: "DebtTransactions",
                newName: "DebtTransaction");

            migrationBuilder.RenameIndex(
                name: "IX_IncomeTransactions_CreditCardAccountId",
                table: "IncomeTransaction",
                newName: "IX_IncomeTransaction_CreditCardAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_IncomeTransactions_AssetAccountId",
                table: "IncomeTransaction",
                newName: "IX_IncomeTransaction_AssetAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_IncomeTransactions_AccountId",
                table: "IncomeTransaction",
                newName: "IX_IncomeTransaction_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_DebtTransactions_DebtAccountId",
                table: "DebtTransaction",
                newName: "IX_DebtTransaction_DebtAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_DebtTransactions_AssetAccountId",
                table: "DebtTransaction",
                newName: "IX_DebtTransaction_AssetAccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IncomeTransaction",
                table: "IncomeTransaction",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DebtTransaction",
                table: "DebtTransaction",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DebtTransaction_Account_AssetAccountId",
                table: "DebtTransaction",
                column: "AssetAccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DebtTransaction_Account_DebtAccountId",
                table: "DebtTransaction",
                column: "DebtAccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeTransaction_Account_AccountId",
                table: "IncomeTransaction",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeTransaction_Account_AssetAccountId",
                table: "IncomeTransaction",
                column: "AssetAccountId",
                principalTable: "Account",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeTransaction_Account_CreditCardAccountId",
                table: "IncomeTransaction",
                column: "CreditCardAccountId",
                principalTable: "Account",
                principalColumn: "Id");
        }
    }
}
