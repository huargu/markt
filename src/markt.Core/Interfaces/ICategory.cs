using markt.Core.Entities;

namespace markt.Core.Interfaces
{
    public interface ICategory
    {
        int CategoryId { get; set; }
        string Title { get; set; }
        int ParentCategoryId { get; set; }
        Category ParentCategory { get; set; }
    }
}