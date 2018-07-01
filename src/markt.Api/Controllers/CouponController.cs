using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using markt.Api.Database.Repositories;
using markt.Api.DTO;
using markt.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace markt.Api.Controllers
{
    [Route("api/coupon")]
    public class CouponController: Controller
    {
        private readonly ICouponRepository _repo;
        private readonly IMapper _mapper;
        public CouponController(ICouponRepository repo, IMapper mapper)
        {
            this._mapper = mapper;
            this._repo = repo;
        }

        [HttpPost]
        public async Task<ActionResult> CreateCoupon([FromBody]CouponDTO coupon)
        {
            var couponRepo = _mapper.Map<Coupon>(coupon);

            _repo.Add(couponRepo);

            if (await _repo.SaveAll())
            {
                return Ok(coupon);
            }

            return BadRequest("Adding category error");
        }
    }
}