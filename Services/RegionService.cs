using GenshinFan_API_REST_ASPNET.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenshinFan_API_REST_ASPNET.Services;

public class RegionService
{
    private readonly AppDbContext _context;
    public RegionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Region>> GetAllAsync()
    {
        return await _context.Regiones.ToListAsync();
    }

    public async Task<Region?> GetByIdAsync(int id)
    {
        return await _context.Regiones.FindAsync(id);
    }

    public async Task<Region> CreateAsync(Region region)
    {
        if (region == null)
        {
            throw new ArgumentNullException(nameof(region), "Region cannot be null");
        }
        _context.Regiones.Add(region);
        await _context.SaveChangesAsync();
        return region;
    }

    public async Task<Region?> UpdateAsync(int id, Region region)
    {
        if (id != region.Id)
        {
            return null;
        }
        _context.Entry(region).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return region;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var region = await _context.Regiones.FindAsync(id);
        if (region == null)
        {
            return false;
        }
        _context.Regiones.Remove(region);
        await _context.SaveChangesAsync();
        return true;
    }

  


}
