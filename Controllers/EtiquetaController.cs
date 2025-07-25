using GenshinFan_API_REST_ASPNET.Entities;
using GenshinFan_API_REST_ASPNET.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace GenshinFan_API_REST_ASPNET.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EtiquetaController : ControllerBase
{
    private readonly EtiquetaService _etiquetaService;
    public EtiquetaController(EtiquetaService etiquetaService)
    {
        _etiquetaService = etiquetaService;
    }

    [HttpGet]
    public async Task<IActionResult> GetEtiquetas()
    {
        var etiquetas = await _etiquetaService.GetAllAsync();
        return Ok(etiquetas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEtiquetaById(int id)
    {
        var etiqueta = await _etiquetaService.GetByIdAsync(id);
        if (etiqueta == null)
        {
            return NotFound();
        }
        return Ok(etiqueta);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEtiqueta([FromBody] Etiqueta etiqueta)
    {
        if (etiqueta == null)
        {
            return BadRequest("Etiqueta cannot be null.");
        }
        var createdEtiqueta = await _etiquetaService.CreateAsync(etiqueta);
        return CreatedAtAction(nameof(GetEtiquetaById), new { id = createdEtiqueta.Id }, createdEtiqueta);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEtiqueta(int id, [FromBody] Etiqueta etiqueta)
    {
        if (etiqueta == null || id != etiqueta.Id)
        {
            return BadRequest("Etiqueta is null or ID mismatch.");
        }
        var updatedEtiqueta = await _etiquetaService.UpdateAsync(id, etiqueta);
        if (updatedEtiqueta == null)
        {
            return NotFound();
        }
        return Ok(updatedEtiqueta);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEtiqueta(int id)
    {
        var result = await _etiquetaService.DeleteAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }


}
