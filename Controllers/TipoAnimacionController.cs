using GenshinFan_API_REST_ASPNET.Entities;
using GenshinFan_API_REST_ASPNET.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenshinFan_API_REST_ASPNET.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoAnimacionController : ControllerBase
{
    private readonly TipoAnimacionService _tipoAnimacionService;
    public TipoAnimacionController(TipoAnimacionService tipoAnimacionService)
    {
        _tipoAnimacionService = tipoAnimacionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tiposAnimacion = await _tipoAnimacionService.GetAllAsync();
        return Ok(tiposAnimacion);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var tipoAnimacion = await _tipoAnimacionService.GetByIdAsync(id);
        if (tipoAnimacion == null)
        {
            return NotFound();
        }
        return Ok(tipoAnimacion);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TipoAnimacion tipoAnimacion)
    {
        if (tipoAnimacion == null)
        {
            return BadRequest("Tipo de animación no puede ser nulo.");
        }
        var createdTipoAnimacion = await _tipoAnimacionService.CreateAsync(tipoAnimacion);
        return CreatedAtAction(nameof(GetById), new { id = createdTipoAnimacion.Id }, createdTipoAnimacion);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] TipoAnimacion tipoAnimacion)
    {
        if (tipoAnimacion == null || id != tipoAnimacion.Id)
        {
            return BadRequest("Datos inválidos para actualizar el tipo de animación.");
        }
        var updatedTipoAnimacion = await _tipoAnimacionService.UpdateAsync(id, tipoAnimacion);
        if (updatedTipoAnimacion == null)
        {
            return NotFound();
        }
        return Ok(updatedTipoAnimacion);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _tipoAnimacionService.DeleteAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }



}
