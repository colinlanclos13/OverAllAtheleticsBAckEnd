using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backEnd_EM.Migrations
{
    /// <inheritdoc />
    public partial class FixWhereToStoreDatePurchase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchasedDate",
                table: "Programs");

            migrationBuilder.AddColumn<DateTime>(
                name: "PurchasedDate",
                table: "programAthletes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchasedDate",
                table: "programAthletes");

            migrationBuilder.AddColumn<DateOnly>(
                name: "PurchasedDate",
                table: "Programs",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }
    }
}
