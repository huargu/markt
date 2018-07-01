namespace markt.Api.DTO
{
    public class ProductDTO
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public CategoryDTO Category { get; set; }

    }
}