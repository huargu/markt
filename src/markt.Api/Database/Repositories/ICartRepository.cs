using System.Threading.Tasks;
using markt.Core.Entities;

namespace markt.Api.Database.Repositories
{
    public interface ICartRepository
    {
        void Add(ShoppingCart cart);
        Task<ShoppingCart> GetCart(int id);
        Task<bool> SaveAll();
    }
}