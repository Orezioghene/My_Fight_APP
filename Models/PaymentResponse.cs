namespace My_Fight_APP.Models
{
    public class PaymentResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public data data { get; set; }
    }

    public class data
    {
        public string link { get; set; }
    }
}
