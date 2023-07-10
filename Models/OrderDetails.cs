using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MerchantApi.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailsId { get; set; }
        [Required]
        public int OrderHeaderId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [Required]
        public int  Quantity { get; set; }
        [Required]
        public string  ItemName{ get; set; }
        [Required]
        public double Price { get; set; }
    }
}
