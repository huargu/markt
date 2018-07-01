using markt.Core.Entities;

namespace markt.Core.Interfaces
{
    public interface IProduct
    {
        int ProductId { get; set; }
        string Title { get; set; }
        double Price { get; set; }
        int CategoryId { get; set; }
        Category Category { get; set; }
    }
}