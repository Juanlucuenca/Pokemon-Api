using PokemonReviewApi.Data;
using PokemonReviewApi.Interfaces;
using PokemonReviewApi.Models;

namespace PokemonReviewApi.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;
        public ReviewRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Review> GetReviewsOfAPokemon(int pokeId)
        {
            var pokemonReviews = _context.Reviews.Where(r => r.Pokemon.Id == pokeId);
            return pokemonReviews;
        }

        public Review GetReview(int reviewId)
        {
            var review = _context.Reviews.Where(r => r.Id == reviewId).FirstOrDefault();
            return review;
        }

        public IEnumerable<Review> getReviews()
        {
            var reviews = _context.Reviews.ToList();
            return reviews;
        }

        public bool ReviewExists(int reviewId)
        {
            return _context.Reviews.Any(r => r.Id == reviewId);
        }
    }
}
