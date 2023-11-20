using Binokool.Services.ProductAPI.Repository.Interface;

namespace Binokool.Services.ProductAPI.AbstractForData
{
    public class DataContext<T>
    {
        private IRepository<T> _repository { get; set; }

        public DataContext(IRepository<T> repository)
        {
            _repository = repository as IRepository<T>;
            if (_repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<T> GetAsync(int id)
        {
            return _repository.GetAsync(id);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public Task<T> CreateOrUpdateAsync(T id)
        {
            return _repository.CreateOrUpdateAsync(id);
        }

        public void SetRepository(IRepository<T> repository)
        {
            _repository = repository as IRepository<T>;
            if (_repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
        }
    }
}
