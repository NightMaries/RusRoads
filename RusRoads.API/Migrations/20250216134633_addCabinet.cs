using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RusRoads.API.Migrations
{
    /// <inheritdoc />
    public partial class addCabinet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cabinet",
                table: "Employee",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cabinet",
                table: "Employee");
        }
    }
}
