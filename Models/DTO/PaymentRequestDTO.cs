namespace MerchantApi.Models.DTO
{
    public class PaymentRequestDTO
    {
        //public string UserId { get; set; }
        public string Email { get; set; } // Customer's email address
        public string Name { get; set; } // Customer's email address
        public int Amount { get; set; } // Payment amount (in your currency)
       // public string CallbackUrl { get; set; } // URL to receive payment status updates

    }
}
