using GenshinFan_API_REST_ASPNET.Entities;
using GenshinFan_API_REST_ASPNET.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenshinFan_API_REST_ASPNET.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RedSocialController : ControllerBase
{
    private readonly RedSocialService _redSocialService;
    public RedSocialController(RedSocialService redSocialService)
    {
        _redSocialService = redSocialService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var redes = await _redSocialService.GetAllAsync();
        return Ok(redes);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var redSocial = await _redSocialService.GetByIdAsync(id);
        if (redSocial == null) return NotFound();
        return Ok(redSocial);
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RedSocial redSocial)
    {
        if (redSocial == null) return BadRequest();
        var createdRed = await _redSocialService.CreateAsync(redSocial);
        return CreatedAtAction(nameof(GetById), new { id = createdRed.Id }, createdRed);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] RedSocial redSocial)
    {
        if (id != redSocial.Id || redSocial == null) return BadRequest();
        var updatedRed = await _redSocialService.UpdateAsync(id, redSocial);
        if (updatedRed == null) return NotFound();
        return Ok(updatedRed);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _redSocialService.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}
