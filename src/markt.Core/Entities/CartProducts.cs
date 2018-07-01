using markt.Core.Interfaces;

namespace markt.Core.Entities
{
    public class CartProducts : ICartProducts
    {
        public int CartId { get; set; }
        public ShoppingCart Cart { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}