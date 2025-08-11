using System.Collections.Generic;
using ECommerce_Api.Handler;
using ECommerce_Api.Repositories;
using ECommerce_Api.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasicController<T> : ControllerBase where T : class
    {
        readonly protected IGenaricRepo<T> _repository;
        public BasicController(IGenaricRepo<T> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> GetItems()
        {
            var items = await _repository.GetAll();
            if (items == null)
            {
                throw new ApiException($"{typeof(T).Name} , {MassageResponse.NoDataFound}", StatusCodes.Status204NoContent);
            }
            return Ok(APIResponse<IEnumerable<T>>.CreateSuccess(items)); ;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<T>> GetItemById(int id)
        {
            var item = await _repository.GetById(id);
            if (item == null)
            {
                throw new ApiException($"{typeof(T).Name} , {MassageResponse.NoDataFound}", StatusCodes.Status204NoContent);
            }
            return Ok(APIResponse<T>.CreateSuccess(item)); ;
        }

    }
}
