using ECommerce_Api.Data;
using ECommerce_Api.Handler;
using ECommerce_Api.Models;
using ECommerce_Api.Models.DTO;
using ECommerce_Api.Repositories;
using ECommerce_Api.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BasicController<Category>
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context, IGenaricRepo<Category> repository) : base(repository)
        {
            _context = context;
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCategory([FromForm] CategoryDto dto)
        {
            if (dto == null)
                throw new ApiException($"{MassageResponse.BadRequest}", StatusCodes.Status400BadRequest);

            var category = new Category()
            {
                Name = dto.Name
            };
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
            return Ok(APIResponse<object>.CreateSuccess(category, MassageResponse.Success));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCategory(int id, [FromForm] CategoryDto dto)
        {
            if (dto == null)
                throw new ApiException($"{MassageResponse.BadRequest}", StatusCodes.Status400BadRequest);

            var category = await _repository.GetById(id);
            if (category == null)
                throw new ApiException($"{MassageResponse.NoDataFound}", StatusCodes.Status404NotFound);

            category.Name = dto.Name;
            _context.Update(category);
            await _context.SaveChangesAsync();
            return Ok(APIResponse<object>.CreateSuccess(category, MassageResponse.Success));
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCategory(int id)
        {

            var category = await _repository.GetById(id);
            if (category == null)
                throw new ApiException($"{MassageResponse.NoDataFound}", StatusCodes.Status404NotFound);

            _context.Remove(category);
            await _context.SaveChangesAsync();
            return Ok(APIResponse<object>.CreateSuccess(category, MassageResponse.Success));
        }


    }
}
