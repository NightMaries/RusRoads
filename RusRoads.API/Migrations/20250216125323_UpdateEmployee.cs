using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RusRoads.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Employee_EmployeeId",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "Post",
                table: "Employee",
                newName: "Position");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Comment",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_EmployeeId",
                table: "Comment",
                newName: "IX_Comment_AuthorId");

            migrationBuilder.AlterColumn<string>(
                name: "PersonalPhone",
                table: "Employee",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalInfo",
                table: "Employee",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Employee_AuthorId",
                table: "Comment",
                column: "AuthorId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Employee_AuthorId",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "Employee",
                newName: "Post");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Comment",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_AuthorId",
                table: "Comment",
                newName: "IX_Comment_EmployeeId");

            migrationBuilder.AlterColumn<string>(
                name: "PersonalPhone",
                table: "Employee",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalInfo",
                table: "Employee",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Employee_EmployeeId",
                table: "Comment",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
