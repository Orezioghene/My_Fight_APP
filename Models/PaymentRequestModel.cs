namespace My_Fight_APP.Models
{
    public class PaymentRequestModel
    {
        public string tx_ref { get; set; }
        public decimal amount { get; set; }
        public string currency { get; set; } = "NGN";
        public string redirect_url { get; set; }
        public Customer customer { get; set; }
        public meta Meta { get; set;  }
       

    }


    public class Customer
    {
        public string email { get; set; }
        public string name { get; set; }
        public string phonenumber { get; set; }
    }

    public class meta
    {
        public int consumer_id { get; set; }
        public string consumer_mac { get; set; }
    }
}   
