namespace ECommerce_Api.Repositories
{
    public interface IGenaricRepo<T> where T : class
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(int id);

    }
}
