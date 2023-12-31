using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interface;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : Controller
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
    public IActionResult GetCategories()
    {
        var categories = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(categories);
    }

    [HttpGet("{categoryId}")]
    [ProducesResponseType(200, Type = typeof(Category))]
    [ProducesResponseType(400)]
    public IActionResult GetCategory(int id)
    {
        if (!_categoryRepository.CategoryExist(id))
        {
            return NotFound();
        }

        var category = _mapper.Map<CategoryDto>(_categoryRepository.GetCategory(id));

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(category);
    }

    [HttpGet("pokemon/{categoryId}")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
    [ProducesResponseType(400)]
    public IActionResult GetPokemonByCategoryId(int categoryId)
    {
        var pokemonCategory = _mapper.Map<List<PokemonDto>>(_categoryRepository.GetPokemonByCategory(categoryId));

        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(pokemonCategory);
    }
}