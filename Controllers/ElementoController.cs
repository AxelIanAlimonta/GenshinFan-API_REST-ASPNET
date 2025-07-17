using GenshinFan_API_REST_ASPNET.Entities;
using GenshinFan_API_REST_ASPNET.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenshinFan_API_REST_ASPNET.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ElementoController : ControllerBase
{
    private readonly ElementoService _elementoService;
    public ElementoController(ElementoService elementoService)
    {
        _elementoService = elementoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var elementos = await _elementoService.GetAllAsync();
        return Ok(elementos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var elemento = await _elementoService.GetByIdAsync(id);
        if (elemento == null)
        {
            return NotFound();
        }
        return Ok(elemento);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Elemento elemento)
    {
        if (elemento == null)
        {
            return BadRequest("Elemento cannot be null.");
        }
        var createdElemento = await _elementoService.CreateAsync(elemento);
        return CreatedAtAction(nameof(GetById), new { id = createdElemento.Id }, createdElemento);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Elemento elemento)
    {
        if (elemento == null || id != elemento.Id)
        {
            return BadRequest("Invalid data.");
        }
        var updatedElemento = await _elementoService.UpdateAsync(id, elemento);
        if (updatedElemento == null)
        {
            return NotFound();
        }
        return Ok(updatedElemento);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _elementoService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }




}
