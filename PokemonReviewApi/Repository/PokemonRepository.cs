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

    public Pokemon GetPokemon(int pokeId)
    {
        return _context.Pokemons.Where(p => p.Id == pokeId).FirstOrDefault();
    }

    public Pokemon GetPokemon(string name)
    {
        return _context.Pokemons.Where(p => p.Name == name).FirstOrDefault(); ;
    }

    public decimal GetPokemonRating(int pokeId)
    {
        var review = _context.Reviews.Where(p => p.Pokemon.Id == pokeId);
        if(review.Count() <= 0)
            return 0;

        return ((decimal)review.Sum(r => r.Rating) / review.Count());
    }

    public ICollection<Pokemon> GetPokemons()
    {
        return this._context.Pokemons
        .OrderBy(p => p.Id)
        .ToList();
    }

    public bool PokemonExist(int pokeId)
    {
        return _context.Pokemons.Any(p => p.Id == pokeId);
    }
}
