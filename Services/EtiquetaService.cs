using GenshinFan_API_REST_ASPNET.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenshinFan_API_REST_ASPNET.Services;

public class EtiquetaService
{
    public readonly AppDbContext _context;

    public EtiquetaService(AppDbContext context)
    {
        _context = context;
    }

    async public Task<List<Etiqueta>> GetAllAsync()
    {
        return await _context.Etiquetas.ToListAsync();
    }

    async public Task<Etiqueta?> GetByIdAsync(int id)
    {
        return await _context.Etiquetas.FindAsync(id);
    }

    async public Task<Etiqueta> CreateAsync(Etiqueta etiqueta)
    {
        _context.Etiquetas.Add(etiqueta);
        await _context.SaveChangesAsync();
        return etiqueta;
    }

    async public Task<Etiqueta?> UpdateAsync(int id, Etiqueta etiqueta)
    {
        if (id != etiqueta.Id)
        {
            return null;
        }
        _context.Entry(etiqueta).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return etiqueta;
    }

    async public Task<bool> DeleteAsync(int id)
    {
        var etiqueta = await _context.Etiquetas.FindAsync(id);
        if (etiqueta == null)
        {
            return false;
        }
        _context.Etiquetas.Remove(etiqueta);
        await _context.SaveChangesAsync();
        return true;
    }


}
