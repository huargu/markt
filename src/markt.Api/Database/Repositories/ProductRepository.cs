using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using markt.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace markt.Api.Database.Repositories
{
    public class ProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            this._context = context;
        }

        public async void Add(Product product)
        {
            await _context.AddAsync(product);
        }

        public void Delete(Product product)
        {
            _context.Remove(product);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await _context.Products
                .Include(c => c.Category)
                .ToListAsync();
            
            return products;
        }

        public async Task<Product> GetProduct(int productId)
        {
            var product = await _context.Products
                .Where(p => p.ProductId == productId)
                .Include(c => c.Category)
                .FirstOrDefaultAsync();
            
            return product;
        }
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}