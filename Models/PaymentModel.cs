namespace My_Fight_APP.Models
{
    public class PaymentModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AmountPaid { get; set; }
        public bool IsSuccessful { get; set; }

    }
}
