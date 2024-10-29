using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace service.Migrations
{
    /// <inheritdoc />
    public partial class DataBaseSetUp1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrainerPhoneNumber",
                table: "Trainers",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "TrainerName",
                table: "Trainers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "TrainerLastName",
                table: "Trainers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "TrainerId",
                table: "Trainers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ReservationTrainerId",
                table: "Reservations",
                newName: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TrainerId",
                table: "Reservations",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Trainers_TrainerId",
                table: "Reservations",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Trainers_TrainerId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_TrainerId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Trainers",
                newName: "TrainerPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Trainers",
                newName: "TrainerName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Trainers",
                newName: "TrainerLastName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Trainers",
                newName: "TrainerId");

            migrationBuilder.RenameColumn(
                name: "TrainerId",
                table: "Reservations",
                newName: "ReservationTrainerId");
        }
    }
}
