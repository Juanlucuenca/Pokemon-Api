using PokemonReviewApi.Models;

namespace PokemonReviewApi.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int categoryId);
        Boolean CategoriesExist(int categoryId);
        ICollection<Pokemon> GetPokemonByCateogry(int categoryId);

    }
}
