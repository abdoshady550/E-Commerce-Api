using ECommerce_Api.Data;
using ECommerce_Api.Handler;
using ECommerce_Api.Models;
using ECommerce_Api.Models.DTO;
using ECommerce_Api.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private List<string> _allowedExtention = new List<string> { ".jpg", ".png" };

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts(
               int page = 1,
               int pageSize = 10,
               string? search = null,
               int? categoryId = null)
        {
            if (page <= 0) page = 1;
            if (pageSize <= 0) pageSize = 10;

            var query = _context.Products.AsQueryable();


            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Name!.Contains(search));
            }


            if (categoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == categoryId.Value);
            }


            var totalItems = await query.CountAsync();


            var products = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();


            var result = new
            {
                TotalItems = totalItems,
                Page = page,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize),
                Items = products
            };

            return Ok(APIResponse<object>.CreateSuccess(result));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetItemById(int id)
        {
            var item = await _context.Products.FindAsync(id);
            if (item == null)
            {
                throw new ApiException($"{typeof(Product).Name} , {MassageResponse.NoDataFound}", StatusCodes.Status204NoContent);
            }
            return Ok(APIResponse<Product>.CreateSuccess(item)); ;
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddProduct([FromForm] CreateProductsDto dto)
        {
            if (dto == null)
                throw new ApiException($"{MassageResponse.BadRequest}", StatusCodes.Status400BadRequest);

            if (!_allowedExtention.Contains(Path.GetExtension(dto.Image.FileName).ToLower()))
                return BadRequest(error: $"{MassageResponse.ImageExtention}");

            using var dataStream = new MemoryStream();
            await dto.Image.CopyToAsync(dataStream);
            var product = new Product()
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                CategoryId = dto.CategoryId,
                Image = dataStream.ToArray(),
            };
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
            return Ok(APIResponse<object>.CreateSuccess(product, MassageResponse.Success));
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProduct(int id, [FromForm] UpdateProductsDto dto)
        {
            if (dto == null)
                throw new ApiException($"{MassageResponse.BadRequest}", StatusCodes.Status400BadRequest);

            var product = await _context.Products.FindAsync(id);

            if (product == null)
                throw new ApiException($"{MassageResponse.NoDataFound}", StatusCodes.Status404NotFound);
            if (dto.Image != null)
            {
                if (!_allowedExtention.Contains(Path.GetExtension(dto.Image.FileName).ToLower()))
                    return BadRequest(error: $"{MassageResponse.ImageExtention}");

                using var dataStream = new MemoryStream();
                await dto.Image.CopyToAsync(dataStream);
                product.Image = dataStream.ToArray();
            }
            if (!string.IsNullOrWhiteSpace(dto.Name))
                product.Name = dto.Name;

            if (!string.IsNullOrWhiteSpace(dto.Description))
                product.Description = dto.Description;

            if (dto.Price != 0)
                product.Price = dto.Price;

            if (dto.CategoryId.HasValue)
                product.CategoryId = dto.CategoryId;


            _context.Update(product);
            await _context.SaveChangesAsync();
            return Ok(APIResponse<object>.CreateSuccess(product, MassageResponse.Success));
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProduct(int id)
        {

            var product = await _context.Products.FindAsync(id);

            if (product == null)
                throw new ApiException($"{MassageResponse.NoDataFound}", StatusCodes.Status404NotFound);
            _context.Remove(product);
            await _context.SaveChangesAsync();
            return Ok(APIResponse<object>.CreateSuccess(product, MassageResponse.Success));
        }

    }
}