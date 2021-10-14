using Microsoft.EntityFrameworkCore.Migrations;

namespace PrisonManagementSystem.Migrations
{
    public partial class addedactivetoduty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Duty",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Duty");
        }
    }
}
