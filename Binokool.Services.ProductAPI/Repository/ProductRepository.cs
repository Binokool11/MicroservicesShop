using AutoMapper;
using Binokool.Services.ProductAPI.DbContexts;
using Binokool.Services.ProductAPI.Models;
using Binokool.Services.ProductAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;


namespace Binokool.Services.ProductAPI.Repository
{
    public class ProductRepository<T> : IRepository<T>
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public ProductRepository(ApplicationDbContext _context, IMapper _mapper)
        {
            context = _context; 
            mapper = _mapper;
        }

        public async Task<T> CreateOrUpdateAsync(T item)
        {
            Product product = mapper.Map<T, Product>(item);
            if (product.ProductId > 0)
            {
                context.Products.Update(product);
            }
            else
            {
                await context.Products.AddAsync(product);
            }
            await context.SaveChangesAsync();
            return mapper.Map<Product, T>(product);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                Product? product = await context.Products.FirstOrDefaultAsync(product => product.ProductId == id);
                if (product == null)
                {
                    return false;
                }
                context.Products.Remove(product);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<T> GetAsync(int id)
        {
            Product? product = await context.Products.FirstOrDefaultAsync(product => product.ProductId == id);
            return mapper.Map<T>(product);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            IEnumerable<Product> productList = await context.Products.ToListAsync();
            return mapper.Map<List<T>>(productList);
        }
        
    }
}
