using MerchantApi.Data;
using MerchantApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using PayStack.Net;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MerchantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private ApiResponse _response;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _db;
        private readonly string token;

        private PayStackApi Paystack { get; set; }

        public PaymentController(IConfiguration configuration,ApplicationDbContext db)
        {
            _db = db;
            _configuration = configuration;
            _response = new();
            token = _configuration["Payment:PaystackSK"];
            Paystack = new PayStackApi(token);

        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> MakePayment(string userId)
        {
            ShoppingCart shoppingCart = _db.ShoppingCarts.Include(u => u.CartItems)
                          .ThenInclude(u => u.Product).FirstOrDefault(u => u.UserId == userId);

            if(shoppingCart == null || shoppingCart.CartItems == null || shoppingCart.CartItems.Count() == 0)
            {
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }

            // Make Payment

            double carttotal = shoppingCart.CartItems.Sum(u => u.Quantity * u.Product.Price);
            TransactionInitializeRequest request = new()
            {
                AmountInKobo = (int)(carttotal*100),
                //Reference = Generate().ToString(),
                Currency = "NGN",
                CallbackUrl = "http://localhost:36222/donate/verify"
            };
      

            var response  = Paystack.Transactions.Initialize(request);
            if (response.Status)
            {
                // Redirect the user to the Paystack payment page
                return Redirect(response.Data.AuthorizationUrl);
            }
        

            _response.Result = shoppingCart;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);

        }
    }
}
