using Azure.Core;
using ECommerce_Api.Data;
using ECommerce_Api.Handler;
using ECommerce_Api.Model.Entities;
using ECommerce_Api.Models;
using ECommerce_Api.Models.DTO;
using ECommerce_Api.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public RequestsController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> CreateBuyingRequest(CreateBuyingRequestDto dto)
        {
            var userId = _userManager.GetUserId(User);

            var cartItems = await _context.CartItems
        .Include(c => c.Cart)
        .Include(c => c.Product)
        .Where(c => dto.CartItemIds.Contains(c.Id) && c.Cart.UserId == userId)
        .ToListAsync();

            if (!cartItems.Any())
                throw new ApiException($"{MassageResponse.BadRequest}", StatusCodes.Status400BadRequest);

            var request = new BuyingRequest
            {
                UserId = userId,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow,
                Items = cartItems.Select(c => new BuyingRequestItem
                {
                    ProductId = c.ProductId,
                    Quantity = c.Quantity,
                    Price = c.Product.Price
                }).ToList()
            };

            _context.BuyingRequests.Add(request);

            _context.CartItems.RemoveRange(cartItems);

            await _context.SaveChangesAsync();

            return Ok(APIResponse<BuyingRequest>.CreateSuccess(request, MassageResponse.Success));
        }

        [HttpGet]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> GetUserRequests()
        {
            var userId = _userManager.GetUserId(User);

            var requests = await _context.BuyingRequests
                .Where(r => r.UserId == userId)
                .Include(r => r.Items)
                .ThenInclude(i => i.Product)
                .ToListAsync();

            return Ok(APIResponse<List<BuyingRequest>>.CreateSuccess(requests, MassageResponse.Success));
        }

        // For Admin


        [HttpGet("all")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllRequests()
        {
            var requests = await _context.BuyingRequests
                .Include(r => r.User)
                .Include(r => r.Items)
                .ThenInclude(i => i.Product)
                .ToListAsync();
            if (requests == null)
                throw new ApiException($"{MassageResponse.NoDataFound}", StatusCodes.Status404NotFound);

            return Ok(APIResponse<List<BuyingRequest>>.CreateSuccess(requests, MassageResponse.Success));
        }

        [HttpPut("{id}/status")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateRequestStatus(int id, UpdateRequestStatusDto dto)
        {
            var request = await _context.BuyingRequests.FindAsync(id);
            if (request == null)
                throw new ApiException($"{MassageResponse.NoDataFound}", StatusCodes.Status404NotFound);

            request.Status = dto.Status;
            await _context.SaveChangesAsync();

            return Ok(APIResponse<BuyingRequest>.CreateSuccess(request, massage: $"Request status updated to{dto.Status}"));
        }
    }
}
