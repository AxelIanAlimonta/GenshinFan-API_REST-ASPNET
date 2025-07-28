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
        var videoDb = await _context.Videos
            .Include(v => v.Etiquetas)
            .FirstOrDefaultAsync(v => v.Id == videoPersonaje.Id);

        if (videoDb == null)
            throw new Exception("Video no encontrado");

        videoDb.Etiquetas?.Clear();

        if (videoPersonaje.Etiquetas != null)
        {
            foreach (var etiqueta in videoPersonaje.Etiquetas)
            {
                Etiqueta etiquetaDb;
                if (etiqueta.Id == 0)
                {
                    etiquetaDb = new Etiqueta { Nombre = etiqueta.Nombre };
                    _context.Etiquetas.Add(etiquetaDb);
                }
                else
                {
                    etiquetaDb = await _context.Etiquetas.FindAsync(etiqueta.Id);
                    if (etiquetaDb == null)
                        throw new Exception($"Etiqueta con Id {etiqueta.Id} no encontrada");
                }
                videoDb.Etiquetas?.Add(etiquetaDb);
            }
        }

        videoDb.Titulo = videoPersonaje.Titulo;
        videoDb.Url = videoPersonaje.Url;
        videoDb.FechaPublicacion = videoPersonaje.FechaPublicacion;
        videoDb.PersonajeId = videoPersonaje.PersonajeId;

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
