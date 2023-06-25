using System.Collections;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interface;

public interface ICountryRepository
{
    ICollection<Country> GetCountries();
    Country GetCountryByOwner(int ownerId);
    Country GetCountry(int id);
    ICollection<Owner> GetOwnersByCountry(int countryId);
    bool CountryExists(int id);
}