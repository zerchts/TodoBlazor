using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoBlazor.Migrations
{
    /// <inheritdoc />
    public partial class AddPicToTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PIC",
                table: "Tasks",
                type: "TEXT",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PIC",
                table: "Tasks");
        }
    }
}
