using PokemonReviewApi.Data;
using PokemonReviewApi.Models;

namespace PokemonReviewApi;

public class PokemonRepository : IPokemonRepository
{
    private readonly DataContext _context;

    public PokemonRepository(DataContext context)
    {
        this._context = context;
    }

    public ICollection<Pokemon> GetPokemons()
    {
        return this._context.Pokemons
        .OrderBy(p => p.Id)
        .ToList();
    }

}
