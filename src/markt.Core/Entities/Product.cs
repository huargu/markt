using markt.Core.Interfaces;

namespace markt.Core.Entities
{
    public class Product : IProduct
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public ICategory Category { get; set; }

        public Product(string _title, double _price, Category _cat)
        {
            Title = _title;
            Price = _price;
            Category = _cat;
        }
    }
}