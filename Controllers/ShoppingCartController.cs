using MerchantApi.Data;
using MerchantApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MerchantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private ApiResponse _response;
        public ShoppingCartController(ApplicationDbContext db)
        {
            _db = db;
            _response = new();
        }
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> AddOrUpdateItemInCart(string userId, int productId, int updateQuantityBy)
        {
            ShoppingCart shoppingCart = _db.ShoppingCarts.FirstOrDefault(u => u.UserId == userId);
            Product product = _db.Products.FirstOrDefault(u => u.Id == productId);
            if (shoppingCart == null) {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }

        }
    }
}
