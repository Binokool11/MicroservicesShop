using AutoMapper;
using Binokool.Services.ShoppingCartAPI.DbContexts;
using Binokool.Services.ShoppingCartAPI.Models;
using Binokool.Services.ShoppingCartAPI.Models.Dto;
using Binokool.Services.ShoppingCartAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Binokool.Services.ShoppingCartAPI.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CartRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> ClearCart(string userId)
        {
            var cartHeaderFromDb = await _context.CartHeaders
                .FirstOrDefaultAsync(header => header.UserId == userId);

            if (cartHeaderFromDb != null)
            {
                _context.CartDetails
                    .RemoveRange(_context.CartDetails.Where(details => details.CartHeaderId == cartHeaderFromDb.CartHeaderId));

                _context.CartHeaders
                    .Remove(cartHeaderFromDb);

                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<CartDto> CreateUpdateCart(CartDto cartDto)
        {
            Cart cart = _mapper.Map<Cart>(cartDto);

            var prod = await _context.Products.FirstOrDefaultAsync(u => u.ProductId == cartDto.CartDetails.FirstOrDefault().ProductId);

            if (prod == null)
            {
                _context.Products.Add(cart.CartDetails.FirstOrDefault().Product);
                await _context.SaveChangesAsync();
            }

            CartHeader cartHeaderFromDb = await _context.CartHeaders.AsNoTracking().FirstOrDefaultAsync(u => u.UserId == cartDto.CartHeader.UserId);

            if (cartHeaderFromDb == null)
            {
                _context.CartHeaders.Add(cart.CartHeader);
                await _context.SaveChangesAsync();
                cart.CartDetails.FirstOrDefault().CartHeaderId = cart.CartHeader.CartHeaderId;
                cart.CartDetails.FirstOrDefault().Product = null;
                _context.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                await _context.SaveChangesAsync();
            }
            else
            {
                var cartDetailsFromDb = await _context.CartDetails.AsNoTracking().FirstOrDefaultAsync(u => u.ProductId == cart.CartDetails.FirstOrDefault().ProductId && u.CartHeaderId == cartHeaderFromDb.CartHeaderId);
                
                if(cartDetailsFromDb == null)
                {
                    cart.CartDetails.FirstOrDefault().CartHeaderId = cartHeaderFromDb.CartHeaderId;
                    cart.CartDetails.FirstOrDefault().Product = null;
                    _context.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                    await _context.SaveChangesAsync();
                }
                else
                {
                    cart.CartDetails.FirstOrDefault().Product = null;
                    cart.CartDetails.FirstOrDefault().Count += cartDetailsFromDb.Count;
                    _context.CartDetails.Update(cart.CartDetails.FirstOrDefault());
                    await _context.SaveChangesAsync();
                }
            }
            return _mapper.Map<CartDto>(cart);
        }

        public async Task<CartDto> GetCartByUserId(string userId)
        {
            Cart cart = new()
            {
                CartHeader = await _context.CartHeaders
                .FirstOrDefaultAsync(header => header.UserId == userId)
            };

            cart.CartDetails = _context.CartDetails
                .Where(details => details.CartHeaderId == cart.CartHeader.CartHeaderId)
                .Include(u => u.Product);

            return _mapper.Map<CartDto>(cart);
        }

        public async Task<bool> RemoveFromCart(int cartDetailsId)
        {
            try
            {
                CartDetails cartDetails = await _context.CartDetails
                .FirstOrDefaultAsync(details => details.CartDetailsId == cartDetailsId);

                int totalCount = _context.CartDetails
                    .Where(details => details.CartHeaderId == cartDetails.CartHeaderId)
                    .Count();

                _context.CartDetails.Remove(cartDetails);

                if (totalCount <= 1)
                {
                    _context.CartHeaders.Remove(await _context.CartHeaders.FirstOrDefaultAsync(headers => headers.CartHeaderId == cartDetails.CartHeaderId));
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }
    }
}
