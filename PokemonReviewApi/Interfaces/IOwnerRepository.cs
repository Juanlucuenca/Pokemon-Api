using PokemonReviewApi.Models;

namespace PokemonReviewApi.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
        Owner GetOwner(int ownerId);
        ICollection<Pokemon> GetPokemonsByOwner(int ownerId);
        ICollection<Owner> GetOwnersByPokemon(int pokeId);
        Boolean OwnerExist(int ownerId);
    }
}
