using Binokool.Services.ShoppingCartAPI.Models.Dto;

namespace Binokool.Services.ShoppingCartAPI.Repository.Interfaces
{
    public interface ICartRepository
    {
        Task<CartDto> GetCartByUserId(string userId);
        Task<CartDto> CreateUpdateCart(CartDto cartDto);
        Task<bool> RemoveFromCart(int cartDetailsId);
        Task<bool> ClearCart(string cartDto);
    }
}
