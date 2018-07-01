using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using markt.Api.Database.Repositories;
using markt.Api.DTO;
using markt.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace markt.Api.Controllers
{
    [Route("api/cart")]
    public class CartController : Controller
    {
        private readonly ICartRepository _repo;
        private readonly IMapper _mapper;
        public CartController(ICartRepository repo, IMapper mapper)
        {
            this._mapper = mapper;
            this._repo = repo;
        }

        [HttpPost]
        public async Task<ActionResult> CreateCart([FromBody] CartDTO cart)
        {
            var cartRepo = _mapper.Map<ShoppingCart>(cart);

            _repo.Add(cartRepo);

            if(await _repo.SaveAll())
            {
                return Ok(cartRepo);
            }

            return BadRequest("Adding cart error");
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCartDetail(int id)
        {
            var cartRepo = await _repo.GetCart(id);

            var cart = _mapper.Map<CartDTO>(cartRepo);

            return Ok(cart);
        }
    }
}