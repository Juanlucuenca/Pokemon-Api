using PokemonReviewApi.Models;

namespace PokemonReviewApi.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int countryId);
        Country GetCountryByOwner(int ownerId);
        ICollection<Owner> GetOwnersFromCountry(int countryId);
        Boolean CountryExist(int countryId);
    }
}
