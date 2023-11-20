using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace Binokool.Services.ShoppingCartAPI.Models
{
    public class CartDetails
    {
        public int CartDetailsId { get; set; }   
        public int CartHeaderId { get; set; }
        [ForeignKey(nameof(CartHeaderId))]
        public virtual CartHeader CartHeader { get; set; }
        [ForeignKey(nameof(ProductId))]
        public int ProductId { get; set;}
        public Product Product { get; set; }    
        public int Count { get; set; }  
    }
}
