using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RusRoads.API.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeAndSbdivision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subdivision",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    LeaderSubdivisionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subdivision", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subdivision_Subdivision_LeaderSubdivisionId",
                        column: x => x.LeaderSubdivisionId,
                        principalTable: "Subdivision",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FIO = table.Column<string>(type: "text", nullable: false),
                    PersonalPhone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DateBorn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SubdivisionId = table.Column<int>(type: "integer", nullable: false),
                    Post = table.Column<string>(type: "text", nullable: false),
                    LeaderId = table.Column<int>(type: "integer", nullable: false),
                    HelperId = table.Column<int>(type: "integer", nullable: false),
                    JobNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Employee_HelperId",
                        column: x => x.HelperId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Employee_LeaderId",
                        column: x => x.LeaderId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Subdivision_SubdivisionId",
                        column: x => x.SubdivisionId,
                        principalTable: "Subdivision",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_HelperId",
                table: "Employee",
                column: "HelperId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_LeaderId",
                table: "Employee",
                column: "LeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_SubdivisionId",
                table: "Employee",
                column: "SubdivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Subdivision_LeaderSubdivisionId",
                table: "Subdivision",
                column: "LeaderSubdivisionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Subdivision");
        }
    }
}
