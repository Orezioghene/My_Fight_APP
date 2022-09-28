using System.Collections;
using System.Collections.Generic;

namespace My_Fight_APP.Models
{
    public class One_way_Ticket
    {
        public int Id { get; set; }
        public ICollection<Flight_Models> Flight_model_collection { get; set; }

    }
}
