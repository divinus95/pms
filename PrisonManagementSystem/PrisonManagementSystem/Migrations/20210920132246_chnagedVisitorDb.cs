using Microsoft.EntityFrameworkCore.Migrations;

namespace PrisonManagementSystem.Migrations
{
    public partial class chnagedVisitorDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visitor_Visiting_VisitingId",
                table: "Visitor");

            migrationBuilder.DropIndex(
                name: "IX_Visitor_VisitingId",
                table: "Visitor");

            migrationBuilder.DropColumn(
                name: "VisitingId",
                table: "Visitor");

            migrationBuilder.AddColumn<int>(
                name: "VisitorId",
                table: "Visiting",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Visiting_VisitorId",
                table: "Visiting",
                column: "VisitorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visiting_Visitor_VisitorId",
                table: "Visiting",
                column: "VisitorId",
                principalTable: "Visitor",
                principalColumn: "VisitorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visiting_Visitor_VisitorId",
                table: "Visiting");

            migrationBuilder.DropIndex(
                name: "IX_Visiting_VisitorId",
                table: "Visiting");

            migrationBuilder.DropColumn(
                name: "VisitorId",
                table: "Visiting");

            migrationBuilder.AddColumn<int>(
                name: "VisitingId",
                table: "Visitor",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Visitor_VisitingId",
                table: "Visitor",
                column: "VisitingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visitor_Visiting_VisitingId",
                table: "Visitor",
                column: "VisitingId",
                principalTable: "Visiting",
                principalColumn: "VisitingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
