using GenshinFan_API_REST_ASPNET.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenshinFan_API_REST_ASPNET.Services;

public class PersonajeService
{
    private readonly AppDbContext _context;
    public PersonajeService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Personaje>> GetAllAsync()
    {
        return await _context.Personajes
            .Include(p => p.Elemento)
            .Include(p => p.Region)
            .Include(p => p.Imagenes)
            .Include(p => p.Videos)
            .Include(p => p.Animaciones)
            .ToListAsync();
    }

    public async Task<Personaje?> GetByIdAsync(int id)
    {
        return await _context.Personajes
            .Include(p => p.Elemento)
            .Include(p => p.Region)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Personaje> CreateAsync(Personaje personaje)
    {
        _context.Personajes.Add(personaje);
        await _context.SaveChangesAsync();
        return personaje;
    }

    public async Task<Personaje?> UpdateAsync(int id, Personaje personaje)
    {
        var existingPersonaje = await _context.Personajes.FindAsync(id);
        if (existingPersonaje == null)
        {
            return null;
        }
        existingPersonaje.Nombre = personaje.Nombre;
        existingPersonaje.Descripcion = personaje.Descripcion;
        existingPersonaje.Rareza = personaje.Rareza;
        existingPersonaje.AvatarURL = personaje.AvatarURL;
        existingPersonaje.SplashArtURL = personaje.SplashArtURL;
        existingPersonaje.SplashArtSinFondoURL = personaje.SplashArtSinFondoURL;
        existingPersonaje.TarjetaURL = personaje.TarjetaURL;
        existingPersonaje.FechaLanzamiento = personaje.FechaLanzamiento;
        existingPersonaje.ElementoId = personaje.ElementoId;
        existingPersonaje.RegionId = personaje.RegionId;
        await _context.SaveChangesAsync();
        return existingPersonaje;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var personaje = await _context.Personajes.FindAsync(id);
        if (personaje == null)
        {
            return false;
        }
        _context.Personajes.Remove(personaje);
        await _context.SaveChangesAsync();
        return true;
    }



}
