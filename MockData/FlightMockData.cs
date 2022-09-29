using My_Fight_APP.Models;
using System.Collections.Generic;

namespace My_Fight_APP.MockData
{
    public class FlightMockData
    {
        public static IEnumerable<FlightModelRoundTicket> FlightModelRoundTickets()
        {
            var Round_tickets = new List<FlightModelRoundTicket>()
            {
                new FlightModelRoundTicket
                {
                    FlightModelId = 1,
                    Id = 1,
                    Flight_Models = new Flight_Models
                    {
                        Id = 1,
                        Flight_name = " Emirates",
                        CreatedOn = System.DateTime.Now,
                        Location =  Destination.Port_Harcourt,
                        Destination = Destination.Lagos,
                        Travel_date = "25th December 2022",
                        TakeOffTime = "03:45:00",
                        flight_Categories= Flight_Categories.Economy,
                        Flight_duration = "6 hours",
                        One_Way_Tickets = new One_way_Ticket
                        {

                        },
                        Round_Tickets = new Round_ticket
                        {

                        }
                        





        


    }
}

            };

            return Round_tickets;
        }
    }
}
