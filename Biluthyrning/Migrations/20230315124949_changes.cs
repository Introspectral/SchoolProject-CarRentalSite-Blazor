using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biluthyrning.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserVehicleBookings");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Booking");

            migrationBuilder.CreateTable(
                name: "UserVehicleBookings",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVehicleBookings", x => new { x.UserId, x.VehicleId, x.BookingId });
                    table.ForeignKey(
                        name: "FK_UserVehicleBookings_Booking_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Booking",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserVehicleBookings_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserVehicleBookings_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserVehicleBookings_BookingId",
                table: "UserVehicleBookings",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVehicleBookings_VehicleId",
                table: "UserVehicleBookings",
                column: "VehicleId");
        }
    }
}
