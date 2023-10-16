using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using PayStack.Net;
using MerchantApi.Data;
using MerchantApi.Models;
using MerchantApi.Models.DTO;
using System.Net;

[Route("api/payment")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly ApplicationDbContext _db;
    private readonly string token;
    private PayStackApi Paystack { get; set; }

    public PaymentController(IConfiguration configuration, ApplicationDbContext db)
    {
        _db = db;
        _configuration = configuration;
        token = _configuration["Payment:PaystackSK"];
        Paystack = new PayStackApi(token);
    }

    [HttpPost("make-payment")]
    public async Task<IActionResult> MakePayment([FromBody] PaymentRequestDTO paymentRequest)
    {

        ShoppingCart shoppingCart = _db.ShoppingCarts
        .Include(u => u.CartItems)
        .ThenInclude(u => u.Product)
        .FirstOrDefault(u => u.UserId == paymentRequest.UserId);

        if (shoppingCart == null || shoppingCart.CartItems == null || shoppingCart.CartItems.Count() == 0)
        {
            return BadRequest("Shopping cart is empty.");
        }

        // Calculate the total amount in kobo (1 Naira = 100 kobo)
          int amountInKobo = (int)(shoppingCart.CartItems.Sum(u => u.Quantity * u.Product.Price) * 100);

        
        var transactionInitializeRequest = new TransactionInitializeRequest
        {
            AmountInKobo = amountInKobo,// Convert amount to kobo (1 Naira = 100 kobo)
            Email = paymentRequest.Email,
            Reference = Guid.NewGuid().ToString(), // Generate a unique reference
            Currency = "NGN", // Nigerian Naira
            CallbackUrl = paymentRequest.CallbackUrl
        };

        var response = Paystack.Transactions.Initialize(transactionInitializeRequest);

        if (response.Status)
        {
            var transaction = new TransactionModel()
            {
                Amount = amountInKobo,  // Convert back to Naira
                Email = paymentRequest.Email,
                TrxRef = Guid.NewGuid().ToString(),
                Name = paymentRequest.Name// Set the customer's name
            };
            await _db.Transactions.AddAsync(transaction);
                   await _db.SaveChangesAsync();
            // Store transaction details or return the authorization URL to the client
            var authorizationUrl = response.Data.AuthorizationUrl;
            return Ok(new { AuthorizationUrl = authorizationUrl });
        }
        else
        {
            // Handle payment initialization failure
            return BadRequest(response.Message);
        }
    }

    [HttpGet("verify")]
    public async Task<IActionResult> Verify(string reference)
    {
        TransactionVerifyResponse response = Paystack.Transactions.Verify(reference);

        if (response != null && response.Data != null)
        {
            if (response.Data.Status == "success")
            {
                var transaction = _db.Transactions.Where(x => x.TrxRef == reference).FirstOrDefault();
                if (transaction != null)
                {
                    transaction.Status = true;
                    _db.Transactions.Update(transaction);
                    await _db.SaveChangesAsync();
                    return Ok("Payment verified successfully.");
                }
            }
        }

        // Handle the case when response, response.Data, or transaction is null
        return BadRequest(new { error = "Payment verification failed." });
    }


    private string GenerateReference()
    {
        // Generate a unique reference as per your requirements
        return Guid.NewGuid().ToString("N");
    }
}



























//using MerchantApi.Data;
//using MerchantApi.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Newtonsoft.Json.Linq;
//using PayStack.Net;
//using System.Net;
//using System.Net.Http.Headers;
//using System.Text;
//using static System.Runtime.InteropServices.JavaScript.JSType;

//namespace MerchantApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PaymentController : ControllerBase
//    {
//        private ApiResponse _response;
//        private string apiUrl;
//        private string apiKey;
//        private readonly IConfiguration _configuration;
//        private readonly ApplicationDbContext _db;
//        private readonly string token;

//        private PayStackApi Paystack { get; set; }

//        public PaymentController(IConfiguration configuration,ApplicationDbContext db)
//        {
//            _db = db;
//            _configuration = configuration;
//            _response = new();
//            string apiKey = "sk_test_ccd47c615e2e9d831256bbe3b7a638a59bb5def3";
//            string apiUrl = "https://api.paystack.co/charge";
//        }

//        [HttpPost]
//        public async Task<ActionResult<ApiResponse>> MakePayment(string userId)
//        {
//            // Create an HttpClient instance
//            using (HttpClient client = new HttpClient())
//            {
//                // Set the API endpoint URL
//                client.BaseAddress = new Uri(apiUrl);

//                // Set the Authorization header with your secret key
//                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

//                // Create the request content as a JSON string
//                string jsonContent = @"{
//                ""email"": ""customer@email.com"",
//                ""amount"": ""10000"",
//                ""bank"": {
//                    ""code"": ""057"",
//                    ""account_number"": ""0000000000""
//                }
//            }";

//                // Convert the JSON string to a ByteArrayContent
//                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

//                // Send the POST request
//                HttpResponseMessage response = await client.PostAsync("", content);

//                // Check the response status
//                if (response.IsSuccessStatusCode)
//                {
//                    // Read the response content as a string
//                    string responseContent = await response.Content.ReadAsStringAsync();
//                    Console.WriteLine("Response:");
//                    Console.WriteLine(responseContent);
//                }
//                else
//                {
//                    Console.WriteLine("Error:");
//                    Console.WriteLine(response.StatusCode);
//                }
//            }


//        // ShoppingCart shoppingCart = _db.ShoppingCarts.Include(u => u.CartItems)
//        //               .ThenInclude(u => u.Product).FirstOrDefault(u => u.UserId == userId);

//        // if(shoppingCart == null || shoppingCart.CartItems == null || shoppingCart.CartItems.Count() == 0)
//        // {
//        //     _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
//        //     _response.IsSuccess = false;
//        //     return BadRequest(_response);
//        // }

//        // // Make Payment
//        //shoppingCart.CartTotal = shoppingCart.CartItems.Sum(u => u.Quantity * u.Product.Price);
//        // TransactionInitializeRequest request = new()
//        // {
//        //     AmountInKobo = (int)(shoppingCart.CartTotal * 100),
//        //     //Reference = Generate().ToString(),
//        //     Currency = "NGN",
//        // };
//        // var response  = Paystack.Transactions.Initialize(request);
//        // if (response.Status)
//        // {
//        //     // Redirect the user to the Paystack payment page
//        //     return Redirect(response.Data.AuthorizationUrl);
//        // }
//        // _response.Result = shoppingCart;
//        // _response.StatusCode = HttpStatusCode.OK;
//        // return Ok(_response);

//    }
//    }
//}
