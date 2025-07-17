using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryOfTheWorld.Migrations
{
    /// <inheritdoc />
    public partial class FixOfPasswordReset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PasswordResets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "PasswordResets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
