using System.Collections;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interface;

public interface ICategoryRepository
{
    ICollection<Category> GetCategories();
    Category GetCategory(int id);
    ICollection<Pokemon> GetPokemonByCategory(int categoryId);
    bool CategoryExist(int id);

}