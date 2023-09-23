using PokemonReviewApi.Models;
namespace PokemonReviewApi;

public interface IPokemonRepository
{
    ICollection<Pokemon> GetPokemons();
    Pokemon GetPokemon(int pokeId);
    Pokemon GetPokemon(string name);
    decimal GetPokemonRating(int pokeId);
    bool PokemonExist(int pokeId);
}
