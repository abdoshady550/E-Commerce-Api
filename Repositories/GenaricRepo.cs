using ECommerce_Api.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_Api.Repositories
{
    public class GenaricRepo<T> : IGenaricRepo<T> where T : class
    {

        private readonly DbSet<T> _entity;
        public GenaricRepo(AppDbContext context)
        {

            _entity = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entity.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _entity.FindAsync(id);
        }
    }
}
