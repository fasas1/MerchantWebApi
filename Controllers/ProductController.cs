using MerchantApi.Data;
using MerchantApi.Models;
using MerchantApi.Models.DTO;
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
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            _response.Result = _db.Products;
          
            _response.StatusCode = HttpStatusCode.OK;
         
            return Ok(_response);
        }

        [HttpGet("{id:int}, Name=GetProduct")]
        public async Task<IActionResult> GetProduct(int id)
        {
           if(id == 0)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            Product product = _db.Products.FirstOrDefault(u => u.Id == id);
            if(product == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
               return NotFound(_response);
            }
            _response.Result = product;
            _response.StatusCode = HttpStatusCode.OK;

            return Ok(_response);
        }

        [HttpPost]
        public async Task <ActionResult<ApiResponse>> CreateProduct([FromBody] ProductCreateDTO productCreateDTO)
        {
            try
            {
                if (productCreateDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(productCreateDTO);
                }
                Product productToCreate = new()
                {
                    Name = productCreateDTO.Name,
                    Price = productCreateDTO.Price,
                    Category = productCreateDTO.Category,
                    Image = productCreateDTO.Image,
                    Description = productCreateDTO.Description
                };
                await _db.Products.AddAsync(productToCreate);
                await _db.SaveChangesAsync();
                _response.Result = productToCreate;
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetProduct", new { id = productToCreate.Id }, _response);
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>{ ex.Message };
            }
            return _response;
        }

        [HttpPut]
        public async Task <ActionResult<ApiResponse>> UpdateProduct(int id,[FromBody]  ProductUpdateDTO productUpdateDTO)
        {
            try
            {
                if (productUpdateDTO == null || id != productUpdateDTO.Id)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest();
                }
                Product productFromDb = await _db.Products.FindAsync(id);
                if(productFromDb == null)
                {
                    return BadRequest();
                }
                {
                    productFromDb.Name = productUpdateDTO.Name;
                    productFromDb.Price = productUpdateDTO.Price;
                    productFromDb.Category = productUpdateDTO.Category;
                    productFromDb.Image = productUpdateDTO.Image;
                    productFromDb.Description = productUpdateDTO.Description;
                }
                _db.Products.Update(productFromDb);
                _db.SaveChanges();
                _response.StatusCode = HttpStatusCode.NoContent;
            }
             catch(Exception ex)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest();
            }
            return _response;
        }
    }
}
