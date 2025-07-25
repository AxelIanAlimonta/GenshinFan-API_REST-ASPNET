using GenshinFan_API_REST_ASPNET.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenshinFan_API_REST_ASPNET.Services;

public class ImagenService
{
    private readonly AppDbContext _context;

    public ImagenService(AppDbContext context)
    {
        _context = context;
    }

    async public Task<List<Imagen>> GetAllAsync()
    {
        return await _context.Imagenes.ToListAsync();
    }

    async public Task<Imagen?> GetByIdAsync(int id)
    {
        return await _context.Imagenes.FindAsync(id);
    }

    async public Task<Imagen> CreateAsync(Imagen imagenPersonaje)
    {
        _context.Imagenes.Add(imagenPersonaje);
        await _context.SaveChangesAsync();
        return imagenPersonaje;
    }

    async public Task<Imagen?> UpdateAsync(int id, Imagen imagenPersonaje)
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
        var imagenPersonaje = await _context.Imagenes.FindAsync(id);
        if (imagenPersonaje == null)
        {
            return false;
        }
        _context.Imagenes.Remove(imagenPersonaje);
        await _context.SaveChangesAsync();
        return true;
    }

    async public Task<List<Imagen>> GetByPersonajeIdAsync(int personajeId)
    {
        return await _context.Imagenes
            .Where(ip => ip.PersonajeId == personajeId)
            .ToListAsync();
    }


}
