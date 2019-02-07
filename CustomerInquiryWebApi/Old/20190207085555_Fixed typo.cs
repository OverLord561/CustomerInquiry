using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.EntityFramework.Migrations
{
    public partial class Fixedtypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerMobileNumer",
                table: "Customers",
                newName: "CustomerMobileNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerMobileNumber",
                table: "Customers",
                newName: "CustomerMobileNumer");
        }
    }
}
