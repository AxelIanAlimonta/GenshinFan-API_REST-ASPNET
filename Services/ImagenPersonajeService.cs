using GenshinFan_API_REST_ASPNET.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenshinFan_API_REST_ASPNET.Services;

public class ImagenPersonajeService
{
    private readonly AppDbContext _context;

    public ImagenPersonajeService(AppDbContext context)
    {
        _context = context;
    }

    async public Task<List<ImagenPersonaje>> GetAllAsync()
    {
        return await _context.ImagenesPersonajes.ToListAsync();
    }

    async public Task<ImagenPersonaje?> GetByIdAsync(int id)
    {
        return await _context.ImagenesPersonajes.FindAsync(id);
    }

    async public Task<ImagenPersonaje> CreateAsync(ImagenPersonaje imagenPersonaje)
    {
        _context.ImagenesPersonajes.Add(imagenPersonaje);
        await _context.SaveChangesAsync();
        return imagenPersonaje;
    }

    async public Task<ImagenPersonaje?> UpdateAsync(int id, ImagenPersonaje imagenPersonaje)
    {
        if (id != imagenPersonaje.Id)
        {
            return null;
        }
        _context.Entry(imagenPersonaje).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return imagenPersonaje;
    }

    async public Task<bool> DeleteAsync(int id)
    {
        var imagenPersonaje = await _context.ImagenesPersonajes.FindAsync(id);
        if (imagenPersonaje == null)
        {
            return false;
        }
        _context.ImagenesPersonajes.Remove(imagenPersonaje);
        await _context.SaveChangesAsync();
        return true;
    }

    async public Task<List<ImagenPersonaje>> GetByPersonajeIdAsync(int personajeId)
    {
        return await _context.ImagenesPersonajes
            .Where(ip => ip.PersonajeId == personajeId)
            .ToListAsync();
    }


}
