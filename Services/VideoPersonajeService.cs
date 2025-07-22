using GenshinFan_API_REST_ASPNET.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenshinFan_API_REST_ASPNET.Services;

public class VideoPersonajeService
{
    private readonly AppDbContext _context;
    public VideoPersonajeService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<VideoPersonaje>> GetAllAsync()
    {
        return await _context.VideosPersonajes.ToListAsync();
    }
    public async Task<VideoPersonaje?> GetByIdAsync(int id)
    {
        return await _context.VideosPersonajes.FindAsync(id);
    }
    public async Task AddAsync(VideoPersonaje videoPersonaje)
    {
        _context.VideosPersonajes.Add(videoPersonaje);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(VideoPersonaje videoPersonaje)
    {
        _context.VideosPersonajes.Update(videoPersonaje);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var videoPersonaje = await GetByIdAsync(id);
        if (videoPersonaje != null)
        {
            _context.VideosPersonajes.Remove(videoPersonaje);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<VideoPersonaje>> GetByPersonajeIdAsync(int personajeId)
    {
        return await _context.VideosPersonajes
            .Where(vp => vp.PersonajeId == personajeId)
            .ToListAsync();
    }

}
