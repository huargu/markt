using System.Linq;
using System.Threading.Tasks;
using markt.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace markt.Api.Database.Repositories
{
    public class CouponRepository
    {
        private readonly DataContext _context;
        public CouponRepository(DataContext context)
        {
            this._context = context;
        }

        public async void Add(Coupon coupon)
        {
            await _context.AddAsync(coupon);
        }

        public async Task<Coupon> GetCoupon(int id)
        {
            var coupon = await _context.Coupons
                .Where(x => x.CouponId == id)
                .FirstOrDefaultAsync();
            
            return coupon;
        }
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}