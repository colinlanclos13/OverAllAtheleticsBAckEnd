using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backEnd_EM.Migrations
{
    /// <inheritdoc />
    public partial class updateInformationOnAthlete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Athletes");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Athletes",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Athletes");

            migrationBuilder.AddColumn<string>(
                name: "Birthday",
                table: "Athletes",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
