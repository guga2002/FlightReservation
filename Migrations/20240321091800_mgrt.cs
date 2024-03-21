using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webia.Migrations
{
    /// <inheritdoc />
    public partial class mgrt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reservations_Flight_Reservation_Number",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Flights_Flight_Number",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "Flight_Reservation_Number",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Flight_Number",
                table: "Flights");

            migrationBuilder.AlterColumn<string>(
                name: "Full_Name",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Departure_city",
                table: "Flights",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Full_Name",
                table: "Reservations",
                column: "Full_Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flights_Departure_city",
                table: "Flights",
                column: "Departure_city",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reservations_Full_Name",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Flights_Departure_city",
                table: "Flights");

            migrationBuilder.AlterColumn<string>(
                name: "Full_Name",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Flight_Reservation_Number",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Departure_city",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Flight_Number",
                table: "Flights",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Flight_Reservation_Number",
                table: "Reservations",
                column: "Flight_Reservation_Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flights_Flight_Number",
                table: "Flights",
                column: "Flight_Number",
                unique: true);
        }
    }
}
