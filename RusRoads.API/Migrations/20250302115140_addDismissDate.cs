using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RusRoads.API.Migrations
{
    /// <inheritdoc />
    public partial class addDismissDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DismissDate",
                table: "Employee",
                type: "timestamp without time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DismissDate",
                table: "Employee");
        }
    }
}
