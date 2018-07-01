namespace markt.Core.Interfaces
{
    public interface IProduct
    {
        int ProductId { get; set; }
        string Title { get; set; }
        double Price { get; set; }
        int CategoryId { get; set; }
        ICategory Category { get; set; }
    }
}