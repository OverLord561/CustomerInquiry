using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.EntityFramework.Migrations
{
    public partial class Uniqueemail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerContactEmail",
                table: "Customers",
                column: "CustomerContactEmail",
                unique: true,
                filter: "[CustomerContactEmail] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_CustomerContactEmail",
                table: "Customers");
        }
    }
}
