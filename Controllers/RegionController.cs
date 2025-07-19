using GenshinFan_API_REST_ASPNET.Entities;
using GenshinFan_API_REST_ASPNET.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenshinFan_API_REST_ASPNET.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegionController : ControllerBase
{
    readonly RegionService _regionService;

    public RegionController(RegionService regionService)
    {
        _regionService = regionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var regiones = await _regionService.GetAllAsync();
        return Ok(regiones);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var region = await _regionService.GetByIdAsync(id);
        if (region == null)
        {
            return NotFound();
        }
        return Ok(region);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Region region)
    {
        if (region == null)
        {
            return BadRequest("Region cannot be null");
        }
        var createdRegion = await _regionService.CreateAsync(region);
        return CreatedAtAction(nameof(GetById), new { id = createdRegion.Id }, createdRegion);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] Region region)
    {
        if (region == null || id != region.Id)
        {
            return BadRequest("Invalid data.");
        }
        var updatedRegion = await _regionService.UpdateAsync(id, region);
        if (updatedRegion == null)
        {
            return NotFound();
        }
        return Ok(updatedRegion);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _regionService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }

}
