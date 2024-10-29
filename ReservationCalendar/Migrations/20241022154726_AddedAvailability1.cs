using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservationCalendar.Migrations
{
    /// <inheritdoc />
    public partial class AddedAvailability1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndAvailability",
                table: "Trainers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartAvailability",
                table: "Trainers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndAvailability",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "StartAvailability",
                table: "Trainers");
        }
    }
}
