using markt.Core.Entities;

namespace markt.Core.Interfaces
{
    public interface ICategoryProducts
    {
        int CategoryId { get; set; }
        Category Category { get; set; }
        int ProductId { get; set; }
        Product Product { get; set; }
    }
}