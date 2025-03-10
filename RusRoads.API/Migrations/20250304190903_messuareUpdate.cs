using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RusRoads.API.Migrations
{
    /// <inheritdoc />
    public partial class messuareUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Messuare_MessuareId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_MessuareId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "MessuareId",
                table: "Employee");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Messuare",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messuare_AuthorId",
                table: "Messuare",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messuare_Employee_AuthorId",
                table: "Messuare",
                column: "AuthorId",
                principalTable: "Employee",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messuare_Employee_AuthorId",
                table: "Messuare");

            migrationBuilder.DropIndex(
                name: "IX_Messuare_AuthorId",
                table: "Messuare");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Messuare");

            migrationBuilder.AddColumn<int>(
                name: "MessuareId",
                table: "Employee",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_MessuareId",
                table: "Employee",
                column: "MessuareId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Messuare_MessuareId",
                table: "Employee",
                column: "MessuareId",
                principalTable: "Messuare",
                principalColumn: "Id");
        }
    }
}
