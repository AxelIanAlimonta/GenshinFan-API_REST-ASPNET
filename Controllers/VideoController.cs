﻿using GenshinFan_API_REST_ASPNET.Entities;
using GenshinFan_API_REST_ASPNET.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenshinFan_API_REST_ASPNET.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VideoController : ControllerBase
{
    private readonly VideoService _videoPersonajeService;
    public VideoController(VideoService videoPersonajeService)
    {
        _videoPersonajeService = videoPersonajeService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Video>>> GetAll()
    {
        var videos = await _videoPersonajeService.GetAllAsync();
        return Ok(videos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Video>> GetById(int id)
    {
        var video = await _videoPersonajeService.GetByIdAsync(id);
        if (video == null)
        {
            return NotFound();
        }
        return Ok(video);
    }

    [HttpPost]
    public async Task<ActionResult<Video>> Create(Video videoPersonaje)
    {
        await _videoPersonajeService.AddAsync(videoPersonaje);
        return CreatedAtAction(nameof(GetById), new { id = videoPersonaje.Id }, videoPersonaje);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Video>> Update(int id, Video videoPersonaje)
    {
        if (id != videoPersonaje.Id)
        {
            return BadRequest();
        }
        await _videoPersonajeService.UpdateAsync(videoPersonaje);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _videoPersonajeService.DeleteAsync(id);
        return NoContent();
    }

    [HttpGet("personaje/{personajeId}")]
    public async Task<ActionResult<List<Video>>> GetByPersonajeId(int personajeId)
    {
        var videos = await _videoPersonajeService.GetByPersonajeIdAsync(personajeId);
        return Ok(videos ?? new List<Video>());
    }

}
