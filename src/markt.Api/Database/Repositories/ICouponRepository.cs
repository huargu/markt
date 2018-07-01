using System.Threading.Tasks;
using markt.Core.Entities;

namespace markt.Api.Database.Repositories
{
    public interface ICouponRepository
    {
        void Add(Coupon coupon);

        Task<Coupon> GetCoupon(int id);
        Task<bool> SaveAll();
    }
}