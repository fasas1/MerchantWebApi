using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MerchantApi.Models.DTO
{
    public class OrderHeaderCreateDTO
    {
        public int OrderHeaderId { get; set; }
        [Required]
        public string PickUpName { get; set; }
        [Required]
        public string PickUpPhoneNumber { get; set; }
        [Required]
        public string PickUpEmail { get; set; }
        public string ApplicationUserId { get; set; }  
        public double OrderTotal { get; set; }

        public string PaystackPaymentIntentId { get; set; }
        public string Status { get; set; }
        public int TotalItems { get; set; }


        public IEnumerable<OrderDetailsCreateDTO> OrderDetailsDTO { get; set; }

    }
}
