using markt.Core.Entities;

namespace markt.Core.Interfaces
{
    public interface ICartProducts
    {
        int CartId { get; set; }
        ShoppingCart Cart { get; set;}
        int ProductId { get; set; }
        Product Product { get; set; }
    }
}