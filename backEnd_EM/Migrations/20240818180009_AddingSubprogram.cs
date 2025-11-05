using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backEnd_EM.Migrations
{
    /// <inheritdoc />
    public partial class AddingSubprogram : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SubPurchase",
                table: "Athletes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Subprograms",
                columns: table => new
                {
                    SubprogramId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProgramJSON = table.Column<string>(type: "text", nullable: false),
                    Month = table.Column<int>(type: "integer", nullable: false),
                    AthletesId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subprograms", x => x.SubprogramId);
                    table.ForeignKey(
                        name: "FK_Subprograms_Athletes_AthletesId",
                        column: x => x.AthletesId,
                        principalTable: "Athletes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subprograms_AthletesId",
                table: "Subprograms",
                column: "AthletesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subprograms");

            migrationBuilder.DropColumn(
                name: "SubPurchase",
                table: "Athletes");
        }
    }
}
