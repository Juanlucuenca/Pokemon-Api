using PokemonReviewApi.Models;

namespace PokemonReviewApi.Interfaces
{
    public interface IReviewRepository
    {
        IEnumerable<Review> getReviews();
        Review GetReview(int reviewId);
        Boolean ReviewExists(int reviewid);
        IEnumerable<Review> GetReviewsOfAPokemon(int pokeId);

    }
}
