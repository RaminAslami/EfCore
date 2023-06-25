using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interface;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository;

public class CountryRepository : ICountryRepository
{
    private readonly DataContext _dataContext;

    public CountryRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public ICollection<Country> GetCountries()
    {
        return _dataContext.Countries.OrderBy(c => c.Id).ToList();
    }

    public Country GetCountryByOwner(int ownerId)
    {
        return _dataContext.Owners.Where(o => o.Id == ownerId)
            .Select(c => c.Country).FirstOrDefault();
    }

    public Country GetCountry(int id)
    {
        return _dataContext.Countries.Where(c => c.Id == id).FirstOrDefault();

    }

    public ICollection<Owner> GetOwnersByCountry(int countryId)
    {

        return _dataContext.Owners.Where(c => c.Country.Id == countryId).ToList();

        // return _dataContext.PokemonCategories.Where(e => e.CategoryId == categoryId)
        //     .Select(c => c.Pokemon).ToList();
        //
        //
    }

    public bool CountryExists(int id)
    {
        return _dataContext.Countries.Any(c => c.Id == id);
    }
}