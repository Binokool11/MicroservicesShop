using AutoMapper;
using Binokool.Services.ProductAPI.DbContexts;
using Binokool.Services.ProductAPI.Models;
using Binokool.Services.ProductAPI.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Binokool.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext context;
        private IMapper mapper;



        public ProductRepository(ApplicationDbContext _context, IMapper _mapper)
        {
            context = _context; 
            mapper = _mapper;
        }

        /// <summary>
        /// Создать или обновить продукт
        /// </summary>
        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Product product = mapper.Map<ProductDto,Product>(productDto);
            if (product.ProductId > 0)
            {
                context.Products.Update(product);   
            }
            else
            {
                await context.Products.AddAsync(product);
            }
            await context.SaveChangesAsync();
            return mapper.Map<Product,ProductDto>(product);
        }
        /// <summary>
        /// Удалить продукт
        /// </summary>
        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product? product = await context.Products.FirstOrDefaultAsync(product => product.ProductId == productId);
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
        /// <summary>
        /// Получить продукт
        /// </summary>

        public async Task<ProductDto> GetProductById(int productId)
        {
            Product? product = await context.Products.FirstOrDefaultAsync(product => product.ProductId == productId);
            return mapper.Map<ProductDto>(product);
        }
        /// <summary>
        /// Получить все продукты
        /// </summary>
        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            IEnumerable<Product> productList = await context.Products.ToListAsync();
            return mapper.Map<List<ProductDto>>(productList); //преобразуем Product в ProductDto
        }
    }
}
