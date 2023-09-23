using PokemonReviewApi.Data;
using PokemonReviewApi.Interfaces;
using PokemonReviewApi.Models;

namespace PokemonReviewApi.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _context;

        public OwnerRepository(DataContext context)
        {
            _context = context;
        }

        public Owner GetOwner(int ownerId)
        {
            var owner = _context.Owners.Where(o => o.Id == ownerId).FirstOrDefault();
            return owner;
        }

        public ICollection<Owner> GetOwners()
        {
            var owners = _context.Owners.ToList();
            return owners;
        }

        public ICollection<Owner> GetOwnersByPokemon(int pokeId)
        {
            var OwnersByPokemons = _context.PokemonsOwners.Where(p => p.PokemonId == pokeId);
        }

        public ICollection<Pokemon> GetPokemonsByOwner(int ownerId)
        {
            throw new NotImplementedException();
        }

        public bool OwnerExist(int ownerId)
        {
            throw new NotImplementedException();
        }
    }
}
