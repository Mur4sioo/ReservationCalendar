using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservationCalendar.Migrations
{
    /// <inheritdoc />
    public partial class AddingAvailability : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndAvailability",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "StartAvailability",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "TrainerAvailability",
                table: "Trainers");

            migrationBuilder.CreateTable(
                name: "TrainerAvailability",
                columns: table => new
                {
                    AvailabilityId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TrainerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    IsBooked = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerAvailability", x => x.AvailabilityId);
                    table.ForeignKey(
                        name: "FK_TrainerAvailability_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "TrainerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainerAvailability_TrainerId",
                table: "TrainerAvailability",
                column: "TrainerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainerAvailability");

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

            migrationBuilder.AddColumn<bool>(
                name: "TrainerAvailability",
                table: "Trainers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
