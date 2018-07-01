using System.Linq;
using System.Threading.Tasks;
using markt.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace markt.Api.Database.Repositories
{
    public class CartRepository
    {
        private readonly DataContext _context;
        public CartRepository(DataContext context)
        {
            this._context = context;
        }
        
        public async Task<ShoppingCart> GetCart(int id)
        {
            var cart = await _context.Carts
                .Where(c => c.CartId == id)
                .Include(cm => cm.Campaigns)
                .ThenInclude(c => c.Campaign)
                .ThenInclude(ct => ct.CampaignId)
                .Include(cp => cp.Coupons)
                .Include(pd => pd.Products)
                .ThenInclude(ct => ct.Product)
                .ThenInclude(p => p.Category)
                .FirstOrDefaultAsync();
            
            return cart;
        }
    }
}