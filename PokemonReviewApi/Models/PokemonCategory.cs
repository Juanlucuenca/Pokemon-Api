namespace PokemonReviewApi.Models
{
    public class PokemonCategory
    {
        public int PokemonId { get; set; }
        public int CateogoryId { get; set; }
        public Pokemon Pokemon { get; set; }
        public Category Category { get; set; }
    }
}
