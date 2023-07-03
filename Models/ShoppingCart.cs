using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace MerchantApi.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ICollection <CartItem> CartItems { get; set; }

        [NotMapped]
        public double CartTotal { get; set; }
        [NotMapped]
        public string PaystackPaymentIntentId { get; set; }
        [NotMapped]
        public string ClientSecret { get; set; }
    }
   
}
