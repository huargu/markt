using System.Threading.Tasks;
using markt.Core.Entities;

namespace markt.Api.Database.Repositories
{
    public interface ICampaignRepository
    {
        void Add(Campaign campaign);
        Task<Campaign> GetCampaign(int id);
        Task<bool> SaveAll();
    }
}