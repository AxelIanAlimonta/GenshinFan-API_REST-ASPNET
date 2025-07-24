using GenshinFan_API_REST_ASPNET.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenshinFan_API_REST_ASPNET.Entities;

[Route("api/[controller]")]
[ApiController]
public class AnimacionController : ControllerBase
{
    private readonly AnimacionService _animacionService;

    public AnimacionController(AnimacionService animacionService)
    {
        _animacionService = animacionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var animaciones = await _animacionService.GetAllAsync();
        return Ok(animaciones);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var animacion = await _animacionService.GetByIdAsync(id);
        if (animacion == null)
        {
            return NotFound();
        }
        return Ok(animacion);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Animacion animacion)
    {
        if (animacion == null)
        {
            return BadRequest("Animación no puede ser nula.");
        }
        var createdAnimacion = await _animacionService.CreateAsync(animacion);
        return CreatedAtAction(nameof(GetById), new { id = createdAnimacion.Id }, createdAnimacion);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Animacion animacion)
    {
        if (animacion == null || id != animacion.Id)
        {
            return BadRequest("Datos de animación inválidos.");
        }
        var updatedAnimacion = await _animacionService.UpdateAsync(id, animacion);
        if (updatedAnimacion == null)
        {
            return NotFound();
        }
        return Ok(updatedAnimacion);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _animacionService.DeleteAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpGet("personaje/{personajeId}")]
    public async Task<IActionResult> GetByPersonajeId(int personajeId)
    {
        var animaciones = await _animacionService.GetByPersonajeIdAsync(personajeId);
        if (animaciones == null || !animaciones.Any())
        {
            return NotFound();
        }
        return Ok(animaciones);
    }

    //obtener animacion por id personaje y nombre del tipo de animacion
    [HttpGet("personaje/{personajeId}/tipo/{tipoAnimacionNombre}")]
    public async Task<IActionResult> GetByPersonajeIdAndTipo(int personajeId, string tipoAnimacionNombre)
    {
        var animaciones = await _animacionService.GetByPersonajeIdAndTipoAsync(personajeId, tipoAnimacionNombre);
        if (animaciones == null || !animaciones.Any())
        {
            return NotFound();
        }
        return Ok(animaciones);
    }


}
