using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using markt.Api.Database.Repositories;
using markt.Api.DTO;
using markt.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace markt.Api.Controllers
{
    [Route("api/category")]
    public class CategoryController : Controller
    {
        private readonly CategoryRepository _repo;
        private readonly IMapper _mapper;
        public CategoryController(CategoryRepository repo, IMapper mapper)
        {
            this._mapper = mapper;
            this._repo = repo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategory(int id)
        {
            var categoryRepo = await _repo.GetCategory(id);

            var category = _mapper.Map<CategoryDTO>(categoryRepo);

            return Ok(category);
        }

        [HttpGet]
        public async Task<ActionResult> GetCategories()
        {
            var categoryRepo = await _repo.GetCategories();

            var categories = _mapper.Map<IEnumerable<CategoryDTO>>(categoryRepo);

            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory([FromBody]CategoryDTO category)
        {
            var categoryRepo = _mapper.Map<Category>(category);

            _repo.Add(categoryRepo);

            if (await _repo.SaveAll())
            {
                return Ok(category);
            }

            return BadRequest("Adding category error");
        }

        [HttpGet("{id}/products")]
        public async Task<ActionResult> GetProducts(int categoryId)
        {
            var productRepo = await _repo.GetProductsOfCategory(categoryId);

            var products = _mapper.Map<IEnumerable<ProductDTO>>(productRepo);

            return Ok(products);
        }
    }
}