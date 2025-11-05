using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backEnd_EM.Migrations
{
    /// <inheritdoc />
    public partial class AddingSubprogramWithNoRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subprograms_Athletes_AthletesId",
                table: "Subprograms");

            migrationBuilder.DropIndex(
                name: "IX_Subprograms_AthletesId",
                table: "Subprograms");

            migrationBuilder.DropColumn(
                name: "AthletesId",
                table: "Subprograms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AthletesId",
                table: "Subprograms",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subprograms_AthletesId",
                table: "Subprograms",
                column: "AthletesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subprograms_Athletes_AthletesId",
                table: "Subprograms",
                column: "AthletesId",
                principalTable: "Athletes",
                principalColumn: "Id");
        }
    }
}
