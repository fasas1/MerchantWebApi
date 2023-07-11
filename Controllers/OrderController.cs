using MerchantApi.Data;
using MerchantApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

using MerchantApi.Utility;
using MerchantApi.Models.DTO;
using Azure;

namespace MerchantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private ApiResponse _response;
        public OrderController(ApplicationDbContext db)
        {
            _db = db;
            _response = new ApiResponse();
        }
        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetOrders(string? userId)
        {
            try
            {
                var orderHeaders = _db.OrderHeaders.Include(u => u.OrderDetails)
                     .ThenInclude(u => u.Product).OrderByDescending(u => u.OrderHeaderId);
                if (!string.IsNullOrEmpty(userId))
                {
                    _response.Result = orderHeaders.Where(u => u.ApplicationUserId == userId);
                }

                else
                {
                    _response.Result = orderHeaders;
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse>> GetOrder(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var orderHeaders = _db.OrderHeaders.Include(u => u.OrderDetails)
                     .ThenInclude(u => u.Product).Where(u => u.OrderHeaderId == id);
                if (orderHeaders == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);

                }

                _response.Result = orderHeaders;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };

            }
            return _response;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> CreateOrder([FromBody] OrderHeaderCreateDTO orderHeaderDTO)
        {
            try
            {
                OrderHeader order = new()
                {
                    ApplicationUserId = orderHeaderDTO.ApplicationUserId,
                    PickUpEmail = orderHeaderDTO.PickUpEmail,
                    PickUpPhoneNumber = orderHeaderDTO.PickUpPhoneNumber,
                    PickUpName = orderHeaderDTO.PickUpName,
                    OrderTotal = orderHeaderDTO.OrderTotal,
                    OrderDate = DateTime.Now,
                    PaystackPaymentIntentId = orderHeaderDTO.PaystackPaymentIntentId,
                    TotalItems = orderHeaderDTO.TotalItems,
                    Status = String.IsNullOrEmpty(orderHeaderDTO.Status) ? SD.status_pending : orderHeaderDTO.Status,
                };
                if (ModelState.IsValid)
                {
                    _db.OrderHeaders.Add(order);
                    _db.SaveChanges();
                    foreach (var orderDetailDTO in orderHeaderDTO.OrderDetailsDTO)
                    {
                        OrderDetails orderDetails = new()
                        {
                            OrderHeaderId = order.OrderHeaderId,
                            ItemName = orderDetailDTO.ItemName,
                            ProductId = orderDetailDTO.ProductId,
                            Price = orderDetailDTO.Price,
                            Quantity = orderDetailDTO.Quantity

                        };
                        _db.OrderDetails.Add(orderDetails);
                    }
                    _db.SaveChanges();
                    _response.Result = order;
                    order.OrderDetails = null;
                    _response.StatusCode = HttpStatusCode.Created;
                    return Ok(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages =
                    new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<ApiResponse>> UpdateOrder(int id,[FromBody] OrderHeaderUpdateDTO orderHeaderUpdateDTO)
        {
            try
            {
                if(orderHeaderUpdateDTO == null || id != orderHeaderUpdateDTO.OrderHeaderId)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest();
                }
                OrderHeader orderFromDb = _db.OrderHeaders.FirstOrDefault(U => U.OrderHeaderId == id);
                if(orderFromDb == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest();
                }
                if (!string.IsNullOrEmpty(orderHeaderUpdateDTO.PickUpName))
                {
                    orderFromDb.PickUpName = orderHeaderUpdateDTO.PickUpName;
                }
                if (!string.IsNullOrEmpty(orderHeaderUpdateDTO.PickUpPhoneNumber))
                {
                    orderFromDb.PickUpPhoneNumber = orderHeaderUpdateDTO.PickUpPhoneNumber;
                }
                if (!string.IsNullOrEmpty(orderHeaderUpdateDTO.PickUpEmail))
                {
                    orderFromDb.PickUpEmail = orderHeaderUpdateDTO.PickUpEmail;
                }
                if (!string.IsNullOrEmpty(orderHeaderUpdateDTO.Status))
                {
                    orderFromDb.Status = orderHeaderUpdateDTO.Status;
                }
                if (!string.IsNullOrEmpty(orderHeaderUpdateDTO.PaystackPaymentIntentId))
                {
                    orderFromDb.PaystackPaymentIntentId = orderHeaderUpdateDTO.PaystackPaymentIntentId;
                }
                _db.SaveChanges();
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages =
                    new List<string>() { ex.ToString() };

            }
            return _response;
        }

    }
}
