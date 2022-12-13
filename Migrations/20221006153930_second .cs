using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace My_Fight_APP.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "One_way_flight_model");

            migrationBuilder.DropTable(
                name: "Round_Ticket_Flight_model");

            migrationBuilder.DropTable(
                name: "Flight_Models");

            migrationBuilder.DropTable(
                name: "One_Way_Tickets");

            migrationBuilder.DropTable(
                name: "round_Tickets");

            migrationBuilder.CreateTable(
                name: "FlightBookings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Flight_name = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    Destination = table.Column<string>(nullable: true),
                    flight_Categories = table.Column<int>(nullable: false),
                    Trip_Type = table.Column<int>(nullable: false),
                    new_destination = table.Column<string>(nullable: true),
                    new_location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightBookings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlightModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightName = table.Column<string>(nullable: true),
                    departure = table.Column<string>(nullable: true),
                    destination = table.Column<string>(nullable: true),
                    AllowRoundTrip = table.Column<bool>(nullable: false),
                    TripAmount = table.Column<decimal>(nullable: true),
                    Travel_date = table.Column<string>(nullable: true),
                    TakeOffTime = table.Column<string>(nullable: true),
                    Flight_duration = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    AmountPaid = table.Column<int>(nullable: false),
                    IsSuccessful = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentModels", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightBookings");

            migrationBuilder.DropTable(
                name: "FlightModel");

            migrationBuilder.DropTable(
                name: "PaymentModels");

            migrationBuilder.CreateTable(
                name: "One_Way_Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_One_Way_Tickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "round_Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Return_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stay_duration = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_round_Tickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flight_Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Destination = table.Column<int>(type: "int", nullable: false),
                    Flight_duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Flight_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<int>(type: "int", nullable: false),
                    One_Way_TicketsId = table.Column<int>(type: "int", nullable: true),
                    Round_TicketsId = table.Column<int>(type: "int", nullable: true),
                    TakeOffTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Travel_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    flight_Categories = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flight_Models_One_Way_Tickets_One_Way_TicketsId",
                        column: x => x.One_Way_TicketsId,
                        principalTable: "One_Way_Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_Models_round_Tickets_Round_TicketsId",
                        column: x => x.Round_TicketsId,
                        principalTable: "round_Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "One_way_flight_model",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Flight_Id = table.Column<int>(type: "int", nullable: true),
                    OneWayId = table.Column<int>(type: "int", nullable: true),
                    OneWayTicketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_One_way_flight_model", x => x.Id);
                    table.ForeignKey(
                        name: "FK_One_way_flight_model_Flight_Models_Flight_Id",
                        column: x => x.Flight_Id,
                        principalTable: "Flight_Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_One_way_flight_model_One_Way_Tickets_OneWayId",
                        column: x => x.OneWayId,
                        principalTable: "One_Way_Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Round_Ticket_Flight_model",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightModelId = table.Column<int>(type: "int", nullable: false),
                    Flight_ModelsId = table.Column<int>(type: "int", nullable: true),
                    RoundTicketId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Round_Ticket_Flight_model", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Round_Ticket_Flight_model_Flight_Models_Flight_ModelsId",
                        column: x => x.Flight_ModelsId,
                        principalTable: "Flight_Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Round_Ticket_Flight_model_round_Tickets_RoundTicketId",
                        column: x => x.RoundTicketId,
                        principalTable: "round_Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flight_Models_One_Way_TicketsId",
                table: "Flight_Models",
                column: "One_Way_TicketsId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_Models_Round_TicketsId",
                table: "Flight_Models",
                column: "Round_TicketsId");

            migrationBuilder.CreateIndex(
                name: "IX_One_way_flight_model_Flight_Id",
                table: "One_way_flight_model",
                column: "Flight_Id");

            migrationBuilder.CreateIndex(
                name: "IX_One_way_flight_model_OneWayId",
                table: "One_way_flight_model",
                column: "OneWayId");

            migrationBuilder.CreateIndex(
                name: "IX_Round_Ticket_Flight_model_Flight_ModelsId",
                table: "Round_Ticket_Flight_model",
                column: "Flight_ModelsId");

            migrationBuilder.CreateIndex(
                name: "IX_Round_Ticket_Flight_model_RoundTicketId",
                table: "Round_Ticket_Flight_model",
                column: "RoundTicketId");
        }
    }
}
