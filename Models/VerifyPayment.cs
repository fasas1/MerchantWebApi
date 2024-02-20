namespace MerchantApi.Models
{
    public class VerifyPayment
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public decimal Amount { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
