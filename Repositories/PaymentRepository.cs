using Microsoft.Extensions.Configuration;
using My_Fight_APP.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace My_Fight_APP.Repositories
{
    public class PaymentRepository : IPaymentInterface
    {

        private FlightDbContext _dbContext;
        private readonly IConfiguration _config;

        public PaymentRepository(IConfiguration config)
        {
            _config = config;
        }
        public PaymentRepository(FlightDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public async FlutterwaveResponse makepayment(PaymentModel payment)
        //{
           

        //    var testSecret = _config.GetValue<string>("Flutterwave:SecretKey");
        //    var url = $"{ _config.GetValue<string>("Flutterwave:url")}/payments";

        //}
        

        public async Task<PaymentResponse> makepayment(PaymentRequestModel payment)
        {
            PaymentResponse deseralize;
            var key = _config.GetValue<string>("Flutterwave:SecretKey");
            var url = $"{ _config.GetValue<string>("Flutterwave:url")}/payments";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {key}");

            var data = JsonConvert.SerializeObject(payment);
            var sendRequest = await client.PostAsync(url, new StringContent(data, Encoding.UTF8, "application/json"));

            var response = await sendRequest.Content.ReadAsStringAsync();

            deseralize= JsonConvert.DeserializeObject<PaymentResponse>(response);   
            return deseralize;
        }

        public async Task<PaymentVerification> VerifyPayment(string transaction_id)
        {
            var key = _config.GetValue<string>("Flutterwave:SecretKey");
            var url = $"{ _config.GetValue<string>("Flutterwave:url")}/transactions/{transaction_id}/verify";
            PaymentVerification deserialize;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {key}");

            var sendRequesr = await client.GetAsync(url);
            var response =await sendRequesr.Content.ReadAsStringAsync();
            deserialize = JsonConvert.DeserializeObject<PaymentVerification>(response);

            return deserialize;

        }

        //public FlutterwaveResponse makepayment(PaymentModel payment)
        //{

        //}
    }
}
