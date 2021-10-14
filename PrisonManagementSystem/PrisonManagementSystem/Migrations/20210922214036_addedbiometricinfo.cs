using Microsoft.EntityFrameworkCore.Migrations;

namespace PrisonManagementSystem.Migrations
{
    public partial class addedbiometricinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ColorOfEye",
                table: "Prisoner",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Height",
                table: "Prisoner",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Prisoner",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorOfEye",
                table: "Prisoner");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Prisoner");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Prisoner");
        }
    }
}
