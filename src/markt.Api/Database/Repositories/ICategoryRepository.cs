using System.Collections.Generic;
using System.Threading.Tasks;
using markt.Core.Entities;

namespace markt.Api.Database.Repositories
{
    public interface ICategoryRepository
    {
        void Add(Category cat);
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategory(int id);
        Task<IEnumerable<Product>> GetProductsOfCategory(int categoryId);
        Task<bool> SaveAll();
    }
}