using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backEnd_EM.Migrations
{
    /// <inheritdoc />
    public partial class AddingSubprogramLevels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "Subprograms",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Subprograms");
        }
    }
}
