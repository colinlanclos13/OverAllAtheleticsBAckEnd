using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backEnd_EM.Migrations
{
    /// <inheritdoc />
    public partial class AddedNameToProgramTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProgramName",
                table: "Programs",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProgramName",
                table: "Programs");
        }
    }
}
