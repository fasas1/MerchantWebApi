using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MerchantApi.Models.DTO
{
    public class OrderDetailsCreateDTO
    {
        [Required]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
