using Microsoft.EntityFrameworkCore;
using PokemonReviewApi.Data;
using PokemonReviewApi.Interfaces;
using PokemonReviewApi.Models;

namespace PokemonReviewApi.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;
        public CountryRepository(DataContext context)
        {
            this._context = context;
        }
        public bool CountryExist(int countryId)
        {
            return _context.Countries.Any(c => c.Id == countryId);
        }

        public ICollection<Country> GetCountries()
        {
            var countries = _context.Countries.ToList();
            return countries;
        }

        public Country GetCountry(int countryId)
        {
            var country = _context.Countries.Where(c => c.Id == countryId).FirstOrDefault();
            return country;
        }

        public Country GetCountryByOwner(int ownerId)
        {
            var ownerCountry = _context.Owners.Where(o => o.Id == ownerId).Select(c => c.Country).FirstOrDefault();
            return ownerCountry;
        }

        public ICollection<Owner> GetOwnersFromCountry(int countryId)
        {
            var Countries = _context.Owners.Where(o => o.Country.Id == countryId).ToList();
            return Countries;
        }
    }
}
