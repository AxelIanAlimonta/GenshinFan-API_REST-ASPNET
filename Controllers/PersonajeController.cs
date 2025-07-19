using GenshinFan_API_REST_ASPNET.Entities;
using GenshinFan_API_REST_ASPNET.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenshinFan_API_REST_ASPNET.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonajeController : ControllerBase
{
    private readonly PersonajeService _personajeService;
    public PersonajeController(PersonajeService personajeService)
    {
        _personajeService = personajeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var personajes = await _personajeService.GetAllAsync();
        return Ok(personajes);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var personaje = await _personajeService.GetByIdAsync(id);
        if (personaje == null)
        {
            return NotFound();
        }
        return Ok(personaje);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Personaje personaje)
    {
        if (personaje == null)
        {
            return BadRequest("Personaje cannot be null.");
        }
        var createdPersonaje = await _personajeService.CreateAsync(personaje);
        return CreatedAtAction(nameof(GetById), new { id = createdPersonaje.Id }, createdPersonaje);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] Personaje personaje)
    {
        if (personaje == null || id != personaje.Id)
        {
            return BadRequest("Invalid personaje data.");
        }
        var updatedPersonaje = await _personajeService.UpdateAsync(id, personaje);
        if (updatedPersonaje == null)
        {
            return NotFound();
        }
        return Ok(updatedPersonaje);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _personajeService.DeleteAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }

}
