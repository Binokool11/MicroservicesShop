namespace Binokool.Services.ProductAPI.Repository.Interface
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<T> CreateOrUpdateAsync(T item);

    }
}
