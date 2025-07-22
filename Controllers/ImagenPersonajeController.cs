using GenshinFan_API_REST_ASPNET.Entities;
using GenshinFan_API_REST_ASPNET.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenshinFan_API_REST_ASPNET.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImagenPersonajeController : ControllerBase
{
    private readonly ImagenPersonajeService _imagenPersonajeService;

    public ImagenPersonajeController(ImagenPersonajeService imagenPersonajeService)
    {
        _imagenPersonajeService = imagenPersonajeService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ImagenPersonaje>>> GetAll()
    {
        var imagenes = await _imagenPersonajeService.GetAllAsync();
        return Ok(imagenes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ImagenPersonaje>> GetById(int id)
    {
        var imagen = await _imagenPersonajeService.GetByIdAsync(id);
        if (imagen == null)
        {
            return NotFound();
        }
        return Ok(imagen);
    }

    [HttpPost]
    public async Task<ActionResult<ImagenPersonaje>> Create(ImagenPersonaje imagenPersonaje)
    {
        var createdImagen = await _imagenPersonajeService.CreateAsync(imagenPersonaje);
        return CreatedAtAction(nameof(GetById), new { id = createdImagen.Id }, createdImagen);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ImagenPersonaje>> Update(int id, ImagenPersonaje imagenPersonaje)
    {
        var updatedImagen = await _imagenPersonajeService.UpdateAsync(id, imagenPersonaje);
        if (updatedImagen == null)
        {
            return NotFound();
        }
        return Ok(updatedImagen);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _imagenPersonajeService.DeleteAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpGet("personaje/{personajeId}")]
    public async Task<ActionResult<List<ImagenPersonaje>>> GetByPersonajeId(int personajeId)
    {
        var imagenes = await _imagenPersonajeService.GetByPersonajeIdAsync(personajeId);
        if (imagenes == null || !imagenes.Any())
        {
            return NotFound();
        }
        return Ok(imagenes);
    }

}
