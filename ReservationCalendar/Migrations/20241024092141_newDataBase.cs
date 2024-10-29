using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservationCalendar.Migrations
{
    /// <inheritdoc />
    public partial class newDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainerAvailability");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trainers",
                table: "Trainers");

            migrationBuilder.RenameColumn(
                name: "ReservationTime",
                table: "Reservations",
                newName: "ReservationStartTime");

            migrationBuilder.AlterColumn<int>(
                name: "TrainerId",
                table: "Trainers",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Trainers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "BookedSlots",
                table: "Trainers",
                type: "TEXT",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<DateTime>(
                name: "TrainerAvailabilityDay",
                table: "Trainers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TrainerAvailabilityEnd",
                table: "Trainers",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TrainerAvailabilityStart",
                table: "Trainers",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ReservationEndTime",
                table: "Reservations",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trainers",
                table: "Trainers",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Trainers",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "BookedSlots",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "TrainerAvailabilityDay",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "TrainerAvailabilityEnd",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "TrainerAvailabilityStart",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "ReservationEndTime",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "ReservationStartTime",
                table: "Reservations",
                newName: "ReservationTime");

            migrationBuilder.AlterColumn<int>(
                name: "TrainerId",
                table: "Trainers",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trainers",
                table: "Trainers",
                column: "TrainerId");

            migrationBuilder.CreateTable(
                name: "TrainerAvailability",
                columns: table => new
                {
                    AvailabilityId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TrainerId = table.Column<int>(type: "INTEGER", nullable: false),
                    BookedSlots = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    IsBooked = table.Column<bool>(type: "INTEGER", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "TEXT", nullable: false)
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
    }
}
