using ECommerce_Api.Data;
using ECommerce_Api.Handler;
using ECommerce_Api.Models;
using ECommerce_Api.Models.DTO;
using ECommerce_Api.Repositories;
using ECommerce_Api.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CartController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("{userId}")]
        public async Task<ActionResult> GetCartByUserId(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ApiException($"{MassageResponse.NoDataFound}", StatusCodes.Status404NotFound);

            }
            var cart = await _context.Carts
                  .Include(c => c.CartItems)
                  .ThenInclude(ci => ci.Product)
                  .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                throw new ApiException($"{MassageResponse.NoDataFound}", StatusCodes.Status404NotFound);

            }
            return Ok(APIResponse<Cart>.CreateSuccess(cart, MassageResponse.Success));
        }

        [HttpPost("{userId}")]
        public async Task<ActionResult> AddCart(string userId, [FromForm] AddToCartDto dto)
        {
            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                cart = new Cart { UserId = userId, CartItems = new List<CartItem>() };
                _context.Carts.Add(cart);
            }

            var existingItem = cart.CartItems
                .FirstOrDefault(ci => ci.ProductId == dto.ProductId);

            if (existingItem != null)
            {
                existingItem.Quantity += dto.Quantity;
            }
            else
            {
                cart.CartItems.Add(new CartItem { ProductId = dto.ProductId, Quantity = dto.Quantity });
            }

            await _context.SaveChangesAsync();

            return Ok(APIResponse<Cart>.CreateSuccess(cart, MassageResponse.Success));
        }

        [HttpDelete("{userId}/{productId}")]
        public async Task<ActionResult> RemoveItemAsync(string userId, int productId)
        {
            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                throw new ApiException($"{MassageResponse.NoDataFound}", StatusCodes.Status404NotFound);
            }
            var item = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
            if (item == null)
            {
                throw new ApiException($"{MassageResponse.NoDataFound}", StatusCodes.Status404NotFound);
            }
            cart.CartItems.Remove(item);
            await _context.SaveChangesAsync();

            return Ok(APIResponse<Cart>.CreateSuccess(cart, MassageResponse.Success));


        }
    }
}
