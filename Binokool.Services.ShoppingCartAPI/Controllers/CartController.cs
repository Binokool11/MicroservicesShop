using Binokool.Services.ShoppingCartAPI.Models.Dto;
using Binokool.Services.ShoppingCartAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Binokool.Services.ShoppingCartAPI.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : Controller
    {
        private readonly ILogger<CartController> _logger;
        private readonly ICartRepository _cartRepository;
        protected ResponseDto _responseDto;

        public CartController(ILogger<CartController> logger, ICartRepository repository)
        {
            _logger = logger;
            _cartRepository = repository;
            _responseDto = new();
        }

        [HttpGet("GetCart/{userId}")]
        [Route("[action]")]
        public async Task<object> GetCart(string userId)
        {
            try
            {
                CartDto cartDto = await _cartRepository.GetCartByUserId(userId);
                _responseDto.Result = cartDto;  
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.DisplayMessage = ex.Message;
            }
            return _responseDto;
        }

        [HttpPost("AddCart")]
        public async Task<object> AddCart(CartDto cartDto)
        {
            try
            {
                CartDto responseCartDto = await _cartRepository.CreateUpdateCart(cartDto);
                _responseDto.Result = responseCartDto;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.DisplayMessage = ex.Message;
            }
            return _responseDto;
        }

        [HttpPost("UpdateCart")]
        public async Task<object> UpdateCart(CartDto cartDto)
        {
            try
            {
                CartDto responseCartDto = await _cartRepository.CreateUpdateCart(cartDto);
                _responseDto.Result = responseCartDto;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.DisplayMessage = ex.Message;
            }
            return _responseDto;
        }

        [HttpPost("RemoveCart")]
        public async Task<object> RemoveCart([FromBody]int cartId)
        {
            try
            {
                bool IsSuccess = await _cartRepository.RemoveFromCart(cartId);
                _responseDto.Result = IsSuccess;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.DisplayMessage = ex.Message;
            }
            return _responseDto;
        }


        [HttpPost("ClearCart")]
        public async Task<object> ClearCart(string cartDto)
        {
            try
            {
                bool IsSuccess = await _cartRepository.ClearCart(cartDto);
                _responseDto.Result = IsSuccess;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.DisplayMessage = ex.Message;
            }
            return _responseDto;
        }


    }
}