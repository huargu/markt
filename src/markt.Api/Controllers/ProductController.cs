using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using markt.Api.Database.Repositories;
using markt.Api.DTO;
using markt.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace markt.Api.Controllers
{
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly ProductRepository _repo;
        private readonly IMapper _mapper;
        public ProductController(ProductRepository repo, IMapper mapper)
        {
            this._mapper = mapper;
            this._repo = repo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            var productRepo = await _repo.GetProduct(id);

            var product = _mapper.Map<ProductDTO>(productRepo);

            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var productsRepo = await _repo.GetProducts();

            var products = _mapper.Map<IEnumerable<ProductDTO>>(productsRepo);

            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody]ProductDTO product)
        {
            var productRepo = _mapper.Map<Product>(product);

            _repo.Add(productRepo);

            if (await _repo.SaveAll())
            {
                return Ok(product);
            }

            return BadRequest("Adding product error");
        }
    }
}