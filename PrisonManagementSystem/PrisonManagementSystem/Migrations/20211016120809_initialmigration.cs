using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PrisonManagementSystem.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CareTaker",
                columns: table => new
                {
                    CareTakerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CareTakerName = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareTaker", x => x.CareTakerId);
                });

            migrationBuilder.CreateTable(
                name: "Cell",
                columns: table => new
                {
                    CellId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CellName = table.Column<string>(type: "text", nullable: true),
                    RenovationIssue = table.Column<string>(type: "text", nullable: true),
                    isOccupied = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cell", x => x.CellId);
                });

            migrationBuilder.CreateTable(
                name: "DutyType",
                columns: table => new
                {
                    DutyTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DutyType", x => x.DutyTypeId);
                });

            migrationBuilder.CreateTable(
                name: "OfficerRank",
                columns: table => new
                {
                    RankId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficerRank", x => x.RankId);
                });

            migrationBuilder.CreateTable(
                name: "PrisonerClassification",
                columns: table => new
                {
                    PrisonerClassificationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Classification = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrisonerClassification", x => x.PrisonerClassificationId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Block",
                columns: table => new
                {
                    BlockId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BlockName = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Facilities = table.Column<string>(type: "text", nullable: true),
                    GenderType = table.Column<string>(type: "text", nullable: true),
                    CareTakerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Block", x => x.BlockId);
                    table.ForeignKey(
                        name: "FK_Block_CareTaker_CareTakerId",
                        column: x => x.CareTakerId,
                        principalTable: "CareTaker",
                        principalColumn: "CareTakerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Duty",
                columns: table => new
                {
                    DutyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DutyName = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    DutyTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duty", x => x.DutyId);
                    table.ForeignKey(
                        name: "FK_Duty_DutyType_DutyTypeId",
                        column: x => x.DutyTypeId,
                        principalTable: "DutyType",
                        principalColumn: "DutyTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Officer",
                columns: table => new
                {
                    OfficerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    ResidentialAddress = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    EmergencyContact = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    RankId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Officer", x => x.OfficerId);
                    table.ForeignKey(
                        name: "FK_Officer_OfficerRank_RankId",
                        column: x => x.RankId,
                        principalTable: "OfficerRank",
                        principalColumn: "RankId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prisoner",
                columns: table => new
                {
                    PrisonerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    OtherName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Offence = table.Column<string>(type: "text", nullable: true),
                    Sentence = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    EmergencyContact = table.Column<string>(type: "text", nullable: true),
                    HealthConditions = table.Column<string>(type: "text", nullable: true),
                    DateConvicted = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ExpectedJailTerm = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateRegistered = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PassportURL = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    Height = table.Column<double>(type: "double precision", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    ColorOfEye = table.Column<string>(type: "text", nullable: true),
                    CellId = table.Column<int>(type: "integer", nullable: false),
                    PrisonerClassificationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prisoner", x => x.PrisonerId);
                    table.ForeignKey(
                        name: "FK_Prisoner_Cell_CellId",
                        column: x => x.CellId,
                        principalTable: "Cell",
                        principalColumn: "CellId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prisoner_PrisonerClassification_PrisonerClassificationId",
                        column: x => x.PrisonerClassificationId,
                        principalTable: "PrisonerClassification",
                        principalColumn: "PrisonerClassificationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfficerDuty",
                columns: table => new
                {
                    OfficerId = table.Column<int>(type: "integer", nullable: false),
                    DutyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficerDuty", x => new { x.DutyId, x.OfficerId });
                    table.ForeignKey(
                        name: "FK_OfficerDuty_Duty_DutyId",
                        column: x => x.DutyId,
                        principalTable: "Duty",
                        principalColumn: "DutyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfficerDuty_Officer_OfficerId",
                        column: x => x.OfficerId,
                        principalTable: "Officer",
                        principalColumn: "OfficerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RemandStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CaseStatement = table.Column<string>(type: "text", nullable: true),
                    NextScheduledCourtDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    PrisonerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemandStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RemandStatus_Prisoner_PrisonerId",
                        column: x => x.PrisonerId,
                        principalTable: "Prisoner",
                        principalColumn: "PrisonerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visitor",
                columns: table => new
                {
                    VisitorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    ResidentAddress = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    PrisonerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitor", x => x.VisitorId);
                    table.ForeignKey(
                        name: "FK_Visitor_Prisoner_PrisonerId",
                        column: x => x.PrisonerId,
                        principalTable: "Prisoner",
                        principalColumn: "PrisonerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visiting",
                columns: table => new
                {
                    VisitingId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArrivalTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DepartedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    VisitorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visiting", x => x.VisitingId);
                    table.ForeignKey(
                        name: "FK_Visiting_Visitor_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitor",
                        principalColumn: "VisitorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Block_CareTakerId",
                table: "Block",
                column: "CareTakerId");

            migrationBuilder.CreateIndex(
                name: "IX_Duty_DutyTypeId",
                table: "Duty",
                column: "DutyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Officer_RankId",
                table: "Officer",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficerDuty_OfficerId",
                table: "OfficerDuty",
                column: "OfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_Prisoner_CellId",
                table: "Prisoner",
                column: "CellId");

            migrationBuilder.CreateIndex(
                name: "IX_Prisoner_PrisonerClassificationId",
                table: "Prisoner",
                column: "PrisonerClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_RemandStatus_PrisonerId",
                table: "RemandStatus",
                column: "PrisonerId");

            migrationBuilder.CreateIndex(
                name: "IX_Visiting_VisitorId",
                table: "Visiting",
                column: "VisitorId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitor_PrisonerId",
                table: "Visitor",
                column: "PrisonerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Block");

            migrationBuilder.DropTable(
                name: "OfficerDuty");

            migrationBuilder.DropTable(
                name: "RemandStatus");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Visiting");

            migrationBuilder.DropTable(
                name: "CareTaker");

            migrationBuilder.DropTable(
                name: "Duty");

            migrationBuilder.DropTable(
                name: "Officer");

            migrationBuilder.DropTable(
                name: "Visitor");

            migrationBuilder.DropTable(
                name: "DutyType");

            migrationBuilder.DropTable(
                name: "OfficerRank");

            migrationBuilder.DropTable(
                name: "Prisoner");

            migrationBuilder.DropTable(
                name: "Cell");

            migrationBuilder.DropTable(
                name: "PrisonerClassification");
        }
    }
}
