
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApi.Dto;
using PokemonReviewApi.Interfaces;
using PokemonReviewApi.Models;
using PokemonReviewApi.Repository;

namespace PokemonReviewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _CategoryRepository;
        private readonly IMapper _Mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this._CategoryRepository = categoryRepository;
            this._Mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        {
            var categories = _Mapper.Map<List<CategoryDto>>(_CategoryRepository.GetCategories());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCateogry(int categoryId)
        {
            if (!_CategoryRepository.CategoriesExist(categoryId))
                return NotFound();

            var Category = _Mapper.Map<CategoryDto>(_CategoryRepository.GetCategory(categoryId));
            return Ok(Category);
        }

        [HttpGet("pokemon/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByCateogry(int categoryId)
        {
            var pokemons = _Mapper.Map<List<PokemonDto>>(_CategoryRepository.GetPokemonByCateogry(categoryId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemons);
        }
    }
}
