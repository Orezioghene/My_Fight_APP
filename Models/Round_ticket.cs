using System.Collections.Generic;

namespace My_Fight_APP.Models
{
    public class Round_ticket
    {
        public int  Id { get; set; }
        public string Stay_duration { get; set; }
        public string Return_date { get; set; }

        public ICollection<Flight_Models> Flight_model_collection { get; set; }


    }
}
