using Microsoft.EntityFrameworkCore.Migrations;

namespace Acme.ProjectDemo.Migrations
{
    public partial class customerDetailsEmailAddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "AppCustomerDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "AppCustomerDetails");
        }
    }
}
