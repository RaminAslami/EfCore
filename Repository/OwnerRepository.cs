using PokemonReviewApp.Data;
using PokemonReviewApp.Interface;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository;

public class OwnerRepository : IOwnerRepository
{

    private readonly DataContext _dataContext;

    public OwnerRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    
    public ICollection<Owner> GetOwners()
    {
        return _dataContext.Owners.ToList();
    }

    public Owner GetOwner(int ownerId)
    {
        return _dataContext.Owners.Where(o => o.Id == ownerId)
            .FirstOrDefault();
    }

    public ICollection<Owner> GetOwnerOfAPokemon(int pokeId)
    {
        return _dataContext.PokemonOwners.Where(p => p.Pokemon.Id == pokeId)
            .Select(o => o.Owner).ToList();

    }

    public ICollection<Pokemon> GetPokemonByOwner(int ownerId)
    {
        return _dataContext.PokemonOwners.Where(p => p.Owner.Id == ownerId)
            .Select(o => o.Pokemon).ToList();
    }

    public bool OwnerExists(int ownerId)
    {
        return _dataContext.Owners.Any(o => o.Id == ownerId);
    }
}