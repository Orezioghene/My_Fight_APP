using My_Fight_APP.Models;
using System.Threading.Tasks;

namespace My_Fight_APP.Repositories
{
    public interface IPaymentInterface
    {
       Task<PaymentResponse> makepayment(PaymentRequestModel payment);
       Task<PaymentVerification> VerifyPayment(string transaction_id);
    }
}
