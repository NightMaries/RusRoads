using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RusRoads.API.Migrations
{
    /// <inheritdoc />
    public partial class updateEventsAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Event");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Event",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
