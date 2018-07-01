using markt.Core.Interfaces;

namespace markt.Core.Entities
{
    public class Category : ICategory
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public int ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
        
        protected Category() {}

        public Category(string _title)
        {
            Title = _title;
        }
    }
}