using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApi.Models;

namespace PokemonReviewApi;
[Route("api/[controller]")]
[ApiController]
public class PokemonController : Controller
{
    private readonly IPokemonRepository _pokemonRepository;

    public PokemonController(IPokemonRepository pokemonRepository)
    {
        this._pokemonRepository = pokemonRepository
    }

    [HttpGet]
    [ProducesResponseType(200, type = typeof(IEnumerable<Pokemon>))]
    public IActionResult getPokemons()
    {
        var pokemons = this._pokemonRepository.GetPokemons();
        
        if (!ModelState.IsValid()) {
            return BadRequest(ModelState);
    
        return Ok(pokemons);
    }
}
