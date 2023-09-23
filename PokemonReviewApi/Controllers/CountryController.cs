using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using PokemonReviewApi.Dto;
using PokemonReviewApi.Interfaces;
using PokemonReviewApi.Models;

namespace PokemonReviewApi.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        public CountryController( ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        public IActionResult GetCountries()
        { 
            var countries = _mapper.Map<List<CountryDto>>( _countryRepository.GetCountries());

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(countries);
        }

        [HttpGet("{countryId}")]
        [ProducesResponseType (200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult GetCountry(int countryId) 
        {
            if (!_countryRepository.CountryExist(countryId))
                return NotFound();

            var country = _mapper.Map<CountryDto>(_countryRepository.GetCountry(countryId));
            return Ok(country);
        }

        [HttpGet("country/{ownerId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult GetCountryByOwner(int ownerId)
        {
            var ownerCountry = _mapper.Map<CountryDto>(_countryRepository.GetCountryByOwner(ownerId));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(ownerCountry);
        }

        [HttpGet("owner/{countryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        [ProducesResponseType(400)]
        public IActionResult GetOwnersFromCountry(int countryId)
        {
            var owners = _mapper.Map<List<OwnerDto>>(_countryRepository.GetOwnersFromCountry(countryId));
            return Ok(owners);
        }

    }
}
