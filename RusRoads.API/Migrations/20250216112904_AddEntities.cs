using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RusRoads.API.Migrations
{
    /// <inheritdoc />
    public partial class AddEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Employee_HelperId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Employee_LeaderId",
                table: "Employee");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Subdivision",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "MessuareId",
                table: "Subdivision",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicantId",
                table: "Event",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LeaderId",
                table: "Employee",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "HelperId",
                table: "Employee",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "MessuareId",
                table: "Employee",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Applicant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FIO = table.Column<string>(type: "text", nullable: false),
                    File = table.Column<byte[]>(type: "bytea", nullable: true),
                    DirectedActivity = table.Column<string>(type: "text", nullable: false),
                    DateAdmission = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    HasComments = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DateApproval = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Region = table.Column<string>(type: "text", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_Employee_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessuareType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessuareType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DocumentId = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messuare",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MessuareTypeId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    DateStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ResponsiblePerson = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    MaterialId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messuare", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messuare_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Messuare_MessuareType_MessuareTypeId",
                        column: x => x.MessuareTypeId,
                        principalTable: "MessuareType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subdivision_MessuareId",
                table: "Subdivision",
                column: "MessuareId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_ApplicantId",
                table: "Event",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_MessuareId",
                table: "Employee",
                column: "MessuareId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_DocumentId",
                table: "Comment",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_EmployeeId",
                table: "Comment",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_AuthorId",
                table: "Material",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Messuare_MaterialId",
                table: "Messuare",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Messuare_MessuareTypeId",
                table: "Messuare",
                column: "MessuareTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_User_EmployeeId",
                table: "User",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Employee_HelperId",
                table: "Employee",
                column: "HelperId",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Employee_LeaderId",
                table: "Employee",
                column: "LeaderId",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Messuare_MessuareId",
                table: "Employee",
                column: "MessuareId",
                principalTable: "Messuare",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Applicant_ApplicantId",
                table: "Event",
                column: "ApplicantId",
                principalTable: "Applicant",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subdivision_Messuare_MessuareId",
                table: "Subdivision",
                column: "MessuareId",
                principalTable: "Messuare",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Employee_HelperId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Employee_LeaderId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Messuare_MessuareId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Applicant_ApplicantId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Subdivision_Messuare_MessuareId",
                table: "Subdivision");

            migrationBuilder.DropTable(
                name: "Applicant");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Messuare");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "MessuareType");

            migrationBuilder.DropIndex(
                name: "IX_Subdivision_MessuareId",
                table: "Subdivision");

            migrationBuilder.DropIndex(
                name: "IX_Event_ApplicantId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Employee_MessuareId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "MessuareId",
                table: "Subdivision");

            migrationBuilder.DropColumn(
                name: "ApplicantId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "MessuareId",
                table: "Employee");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Subdivision",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LeaderId",
                table: "Employee",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HelperId",
                table: "Employee",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Employee_HelperId",
                table: "Employee",
                column: "HelperId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Employee_LeaderId",
                table: "Employee",
                column: "LeaderId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
