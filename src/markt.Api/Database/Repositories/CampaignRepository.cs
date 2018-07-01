using System.Linq;
using System.Threading.Tasks;
using markt.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace markt.Api.Database.Repositories
{
    public class CampaignRepository
    {
        private readonly DataContext _context;
        public CampaignRepository(DataContext context)
        {
            this._context = context;
        }

        public async void Add(Campaign campaign)
        {
            await _context.AddAsync(campaign);
        }

        public async Task<Campaign> GetCampaign(int id)
        {
            var campaign = await _context.Campaigns
                .Where(c => c.CampaignId == id)
                .FirstOrDefaultAsync();
            
            return campaign;
        }
    }
}