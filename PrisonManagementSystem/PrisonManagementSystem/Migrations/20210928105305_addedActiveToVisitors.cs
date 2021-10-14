using Microsoft.EntityFrameworkCore.Migrations;

namespace PrisonManagementSystem.Migrations
{
    public partial class addedActiveToVisitors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Visitor",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
               name: "DepartedTime",
               table: "Visiting",
               type: "DateTime",
               nullable: true,
               defaultValue: 0000-00-00);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Visitor");
        }
    }
}
