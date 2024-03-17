using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Log4netExample.Api.Migrations
{
    /// <inheritdoc />
    public partial class addLogger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Logger",
                table: "Log",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logger",
                table: "Log");
        }
    }
}
