using PokemonReviewApi.Models;
namespace PokemonReviewApi;

public interface IPokemonRepository
{
    ICollection<Pokemon> GetPokemons();
}
