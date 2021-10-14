using Microsoft.EntityFrameworkCore.Migrations;

namespace PrisonManagementSystem.Migrations
{
    public partial class changedOficerFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duty",
                table: "Officer");

            migrationBuilder.RenameColumn(
                name: "VisitorId",
                table: "Officer",
                newName: "OfficerId");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Officer",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Officer");

            migrationBuilder.RenameColumn(
                name: "OfficerId",
                table: "Officer",
                newName: "VisitorId");

            migrationBuilder.AddColumn<string>(
                name: "Duty",
                table: "Officer",
                type: "text",
                nullable: true);
        }
    }
}
