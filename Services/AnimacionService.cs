using GenshinFan_API_REST_ASPNET.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenshinFan_API_REST_ASPNET.Services;

public class AnimacionService
{
    private readonly AppDbContext _context;
    public AnimacionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Animacion>> GetAllAsync()
    {
        return await _context.Animaciones
            .Include(a => a.TipoAnimacion)
            .ToListAsync();
    }

    public async Task<Animacion?> GetByIdAsync(int id)
    {
        return await _context.Animaciones
            .Include(a => a.TipoAnimacion)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<Animacion> CreateAsync(Animacion animacion)
    {
        _context.Animaciones.Add(animacion);
        await _context.SaveChangesAsync();
        return animacion;
    }

    public async Task<Animacion?> UpdateAsync(int id, Animacion animacion)
    {
        if (id != animacion.Id)
        {
            return null;
        }
        _context.Entry(animacion).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return animacion;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var animacion = await _context.Animaciones.FindAsync(id);
        if (animacion == null)
        {
            return false;
        }
        _context.Animaciones.Remove(animacion);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Animacion>> GetByTipoAnimacionAsync(string tipoAnimacion)
    {
        return await _context.Animaciones
            .Include(a => a.TipoAnimacion)
            .Where(a => a.TipoAnimacion != null && a.TipoAnimacion.Nombre == tipoAnimacion)
            .ToListAsync();
    }
}
