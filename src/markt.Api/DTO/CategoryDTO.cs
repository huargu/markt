using System.Collections.Generic;

namespace markt.Api.DTO
{
    public class CategoryDTO
    {
        public string Title { get; set; }
        public CategoryDTO ParentCategory { get; set; }
        public IEnumerable<ProductDTO> Products { get; set; }
    }
}