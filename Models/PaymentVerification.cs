namespace My_Fight_APP.Models
{
    public class PaymentVerification
    {
        public string status { get; set; }
        public string messaage { get; set; }
        public VerifyData Data { get; set; }
    }

    public class VerifyData
    {
        public long Id { get; set; }
        public long amount { get; set; }
        public string tx_ref { get; set; }
        //public string flw_ref { get; set; }
        //public string currency { get; set; }
       
        //public string device_fingerprint { get; set; }
    }
}

//{
//    "status": "success",
//  "message": "Transaction fetched successfully",
//  "data": {
//        "id": 288200108,
//    "tx_ref": "LiveCardTest",
//    "flw_ref": "YemiDesola/FLW275407301",
//    "device_fingerprint": "N/A",
//    "amount": 100,
//    "currency": "NGN",
//    "charged_amount": 100,
//    "app_fee": 1.4,
//    "merchant_fee": 0,
//    "processor_response": "Approved by Financial Institution",
//    "auth_model": "PIN",
//    "ip": "::ffff:10.5.179.3",
//    "narration": "CARD Transaction ",
//    "status": "successful",
//    "payment_type": "card",
//    "created_at": "2020-07-15T14:31:16.000Z",
//    "account_id": 17321,
//    "card": {
//            "first_6digits": "232343",
//      "last_4digits": "4567",
//      "issuer": "FIRST CITY MONUMENT BANK PLC",
//      "country": "NIGERIA NG",
//      "type": "VERVE",
//      "token": "flw-t1nf-4676a40c7ddf5f12scr432aa12d471973-k3n",
//      "expiry": "02/23"
//    },
//    "meta": null,
//    "amount_settled": 98.6,
//    "customer": {
//            "id": 216519823,
//      "name": "Yemi Desola",
//      "phone_number": "N/A",
//      "email": "user@gmail.com",
//      "created_at": "2020-07-15T14:31:15.000Z"
//    }
//    }
//}