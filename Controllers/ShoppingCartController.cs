﻿using MerchantApi.Data;
using MerchantApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            ShoppingCart shoppingCart = _db.ShoppingCarts.Include(u => u.CartItems).FirstOrDefault(u => u.UserId == userId);
            Product product = _db.Products.FirstOrDefault(u => u.Id == productId);
            if (product == null) {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            if (shoppingCart == null && updateQuantityBy > 0)
            {
                // Create Shipping Cart & Cart Item
                ShoppingCart newCart = new() { UserId = userId };
                _db.ShoppingCarts.Add(newCart);
                _db.SaveChanges();

                CartItem newCartItem = new()
                {
                    ProductId = productId,
                    Quantity = updateQuantityBy,
                    ShoppingCartId = newCart.Id,
                    Product = null
                };
                _db.CartItems.Add(newCartItem);
                _db.SaveChanges();
            }
            else
            {
                //shoppig cart exist 
                CartItem cartItemInCart = shoppingCart.CartItems.FirstOrDefault(u => u.ProductId == productId);
                if (cartItemInCart == null)
                {
                    // Item does not exist in shopping cart
                    CartItem newCartItem = new()
                    {
                        ProductId = productId,
                        Quantity = updateQuantityBy,
                        ShoppingCartId = shoppingCart.Id,
                        Product = null
                    };
                    _db.CartItems.Add(newCartItem);
                    _db.SaveChanges();

                }
                else
                {
                    // Item already exist in the shopping cart and we have to update quantity
                    int newQuantity = cartItemInCart.Quantity + updateQuantityBy;
                     if(updateQuantityBy == 0 || updateQuantityBy <= 0)
                    {
                        // remove cart item from cart and if it is the only item then remove cart
                        _db.CartItems.Remove(cartItemInCart);
                        if(shoppingCart.CartItems.Count() == 1)
                        {
                            _db.ShoppingCarts.Remove(shoppingCart);
                        }
                        _db.SaveChanges();
                    }
                    else
                    {
                        //update quantity
                        cartItemInCart.Quantity = newQuantity;
                    }
                    _db.SaveChanges();
                }
            }
            return _response;
        }
    }
}
