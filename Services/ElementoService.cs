using GenshinFan_API_REST_ASPNET.Entities;
using Microsoft.EntityFrameworkCore;
namespace GenshinFan_API_REST_ASPNET.Services;

public class ElementoService
{
    private readonly AppDbContext _context;

    public ElementoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Elemento>> GetAllAsync()
    {
        return await _context.Elementos.ToListAsync();
    }

    public async Task<Elemento?> GetByIdAsync(int id)
    {
        return await _context.Elementos.FindAsync(id);
    }

    public async Task<Elemento> CreateAsync(Elemento elemento)
    {
        _context.Elementos.Add(elemento);
        await _context.SaveChangesAsync();
        return elemento;
    }

    public async Task<Elemento?> UpdateAsync(int id, Elemento elemento)
    {
        if (id != elemento.Id)
        {
            return null;
        }
        _context.Entry(elemento).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return elemento;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var elemento = await _context.Elementos.FindAsync(id);
        if (elemento == null)
        {
            return false;
        }
        _context.Elementos.Remove(elemento);
        await _context.SaveChangesAsync();
        return true;
    }

}
