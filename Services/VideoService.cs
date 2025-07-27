using GenshinFan_API_REST_ASPNET.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenshinFan_API_REST_ASPNET.Services;

public class VideoService
{
    private readonly AppDbContext _context;
    public VideoService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Video>> GetAllAsync()
    {
        return await _context.Videos.Include(v => v.Etiquetas).ToListAsync();
    }
    public async Task<Video?> GetByIdAsync(int id)
    {
        return await _context.Videos
            .Include(v => v.Etiquetas)
            .FirstOrDefaultAsync(v => v.Id == id);
    }

    public async Task AddAsync(Video videoPersonaje)
    {
        _context.Videos.Add(videoPersonaje);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(Video videoPersonaje)
    {
        _context.Videos.Update(videoPersonaje);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var videoPersonaje = await GetByIdAsync(id);
        if (videoPersonaje != null)
        {
            _context.Videos.Remove(videoPersonaje);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Video>> GetByPersonajeIdAsync(int personajeId)
    {
        return await _context.Videos
            .Where(vp => vp.PersonajeId == personajeId)
            .Include(vp => vp.Etiquetas)
            .ToListAsync();
    }

}
