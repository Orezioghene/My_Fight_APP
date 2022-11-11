using Microsoft.EntityFrameworkCore.Migrations;

namespace My_Fight_APP.Migrations
{
    public partial class newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentModels");

            migrationBuilder.AddColumn<bool>(
                name: "Isdeleted",
                table: "FlightBookings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "numberOfSeats",
                table: "FlightBookings",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Isdeleted",
                table: "FlightBookings");

            migrationBuilder.DropColumn(
                name: "numberOfSeats",
                table: "FlightBookings");

            migrationBuilder.CreateTable(
                name: "PaymentModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountPaid = table.Column<int>(type: "int", nullable: false),
                    IsSuccessful = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentModels", x => x.Id);
                });
        }
    }
}
