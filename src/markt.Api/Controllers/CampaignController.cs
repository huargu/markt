using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using markt.Api.Database.Repositories;
using markt.Api.DTO;
using markt.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace markt.Api.Controllers
{
    [Route("api/campaign")]
    public class CampaignController: Controller
    {
        private readonly ICampaignRepository _repo;
        private readonly IMapper _mapper;
        public CampaignController(ICampaignRepository repo, IMapper mapper)
        {
            this._mapper = mapper;
            this._repo = repo;
        }

        [HttpPost]
        public async Task<ActionResult> CreateCoupon([FromBody]CampaignDTO campaign)
        {
            var campaignRepo = _mapper.Map<Campaign>(campaign);

            _repo.Add(campaignRepo);

            if (await _repo.SaveAll())
            {
                return Ok(campaign);
            }

            return BadRequest("Adding category error");
        }
    }
}