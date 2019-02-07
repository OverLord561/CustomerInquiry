using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.EntityFramework.Migrations
{
    public partial class FixedthatCurrencyisrequiredfortransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Currencies_CurrencyID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Customers_CustomerID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Statuses_StatusID",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "StatusID",
                table: "Transactions",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Transactions",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "CurrencyID",
                table: "Transactions",
                newName: "CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_StatusID",
                table: "Transactions",
                newName: "IX_Transactions_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_CustomerID",
                table: "Transactions",
                newName: "IX_Transactions_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_CurrencyID",
                table: "Transactions",
                newName: "IX_Transactions_CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Currencies_CurrencyId",
                table: "Transactions",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "CurrencyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Customers_CustomerId",
                table: "Transactions",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Statuses_StatusId",
                table: "Transactions",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Currencies_CurrencyId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Customers_CustomerId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Statuses_StatusId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Transactions",
                newName: "StatusID");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Transactions",
                newName: "CustomerID");

            migrationBuilder.RenameColumn(
                name: "CurrencyId",
                table: "Transactions",
                newName: "CurrencyID");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_StatusId",
                table: "Transactions",
                newName: "IX_Transactions_StatusID");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_CustomerId",
                table: "Transactions",
                newName: "IX_Transactions_CustomerID");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_CurrencyId",
                table: "Transactions",
                newName: "IX_Transactions_CurrencyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Currencies_CurrencyID",
                table: "Transactions",
                column: "CurrencyID",
                principalTable: "Currencies",
                principalColumn: "CurrencyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Customers_CustomerID",
                table: "Transactions",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Statuses_StatusID",
                table: "Transactions",
                column: "StatusID",
                principalTable: "Statuses",
                principalColumn: "StatusID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
