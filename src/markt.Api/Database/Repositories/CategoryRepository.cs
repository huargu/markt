using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using markt.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace markt.Api.Database.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context)
        {
            this._context = context;
        }

        public async void Add(Category cat)
        {
            await _context.AddAsync(cat);
        }

        public void Delete(Category cat)
        {
            _context.Remove(cat);
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var cats = await _context.Categories
                .Include(c => c.ParentCategory)
                .ToListAsync();
            
            return cats;
        }

        public async Task<Category> GetCategory(int id)
        {
            var cat = await _context.Categories
                .Where(c => c.CategoryId == id)
                .Include(p => p.ParentCategory)
                .FirstOrDefaultAsync();
            
            return cat;
        }

        public async Task<IEnumerable<Product>> GetProductsOfCategory(int categoryId)
        {
            var products = await _context.Products
                .Where(p => p.CategoryId == categoryId)
                .Include(c => c.Category)
                .ToListAsync();

            return products;
        }
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}