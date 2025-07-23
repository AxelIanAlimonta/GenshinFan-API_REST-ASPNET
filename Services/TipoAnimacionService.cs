using GenshinFan_API_REST_ASPNET.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenshinFan_API_REST_ASPNET.Services;

public class TipoAnimacionService
{

    private readonly AppDbContext _context;
    public TipoAnimacionService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<TipoAnimacion>> GetAllAsync()
    {
        return await _context.TiposAnimaciones.ToListAsync();
    }
    public async Task<TipoAnimacion?> GetByIdAsync(int id)
    {
        return await _context.TiposAnimaciones.FindAsync(id);
    }
    public async Task<TipoAnimacion> CreateAsync(TipoAnimacion tipoAnimacion)
    {
        _context.TiposAnimaciones.Add(tipoAnimacion);
        await _context.SaveChangesAsync();
        return tipoAnimacion;
    }
    public async Task<TipoAnimacion?> UpdateAsync(int id, TipoAnimacion tipoAnimacion)
    {
        if (id != tipoAnimacion.Id)
        {
            return null;
        }
        _context.Entry(tipoAnimacion).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return tipoAnimacion;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var tipoAnimacion = await _context.TiposAnimaciones.FindAsync(id);
        if (tipoAnimacion == null)
        {
            return false;
        }
        _context.TiposAnimaciones.Remove(tipoAnimacion);
        await _context.SaveChangesAsync();
        return true;
    }
}
