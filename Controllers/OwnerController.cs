using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interface;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OwnerController : Controller
{

    private readonly IOwnerRepository _ownerRepository;
    private readonly IMapper _mapper;
    
    public OwnerController(IOwnerRepository ownerRepository, IMapper mapper)
    {
        _ownerRepository = ownerRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
    public IActionResult GetOwners()
    {
        var owners = _mapper.Map<List<OwnerDto>>(
            _ownerRepository.GetOwners());

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

       return Ok(owners);
    }

    [HttpGet("{ownerId}")]
    [ProducesResponseType(200, Type = typeof(Owner))]
    [ProducesResponseType(400)]
    public IActionResult GetOwner(int id)
    {
        if (!_ownerRepository.OwnerExists(id))
        {
            return NotFound();
        }

        var owner = _mapper.Map<List<OwnerDto>>(_ownerRepository.GetOwners());

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(owner);
    }

    [HttpGet("{ownerId}/pokemon")]
    [ProducesResponseType(200, Type = typeof(Owner))]
    [ProducesResponseType(400)]
    public IActionResult GetPokemonByOwner(int ownerId)
    {
        if (!_ownerRepository.OwnerExists(ownerId))
        {
            return BadRequest();
        }

        var getPokemon = _mapper.Map<Pokemon>(_ownerRepository
            .GetPokemonByOwner(ownerId));

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(getPokemon);
    }


}
