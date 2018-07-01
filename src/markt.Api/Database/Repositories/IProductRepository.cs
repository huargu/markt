using System.Collections.Generic;
using System.Threading.Tasks;
using markt.Core.Entities;

namespace markt.Api.Database.Repositories
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Delete(Product product);
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int productId);
        Task<bool> SaveAll();
    }
}