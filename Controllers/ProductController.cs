using MerchantApi.Data;
using MerchantApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MerchantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private ApiResponse _response;
        public ProductController(ApplicationDbContext db)
        {
            _db = db;
            _response = new ApiResponse();
        }
        [HttpPost]
        public async Task<IActionResult> GetProducts()
        {
            _response.Result = _db.Products;
            _response.StatusCode = HttpStatusCode.OK;
         
            return Ok(_response);
        }
    }
}
