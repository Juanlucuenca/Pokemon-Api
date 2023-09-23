using PokemonReviewApi.Data;
using PokemonReviewApi.Interfaces;
using PokemonReviewApi.Models;

namespace PokemonReviewApi.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context) 
        {
            this._context = context;
        }

        public bool CategoriesExist(int categoryId)
        {
            var cateogry = _context.Cateogries.Any(c => c.Id == categoryId);
            return cateogry;
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Cateogries.ToList();
        }

        public Category GetCategory(int categoryId)
        {
            return _context.Cateogries.Where(c => c.Id == categoryId).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonByCateogry(int categoryId)
        {
            return _context.PokemonsCategories.Where(c => c.CateogoryId == categoryId).Select(e => e.Pokemon).ToList();
            
        }
    }
}
