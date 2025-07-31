using GenshinFan_API_REST_ASPNET.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenshinFan_API_REST_ASPNET.Services;

public class RedSocialService
{
    private readonly AppDbContext _context;
    public RedSocialService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<RedSocial>> GetAllAsync()
    {
        return await _context.RedesSociales.ToListAsync();
    }
    public async Task<RedSocial?> GetByIdAsync(int id)
    {
        return await _context.RedesSociales.FindAsync(id);
    }
    public async Task<RedSocial> CreateAsync(RedSocial redSocial)
    {
        _context.RedesSociales.Add(redSocial);
        await _context.SaveChangesAsync();
        return redSocial;
    }
    public async Task<RedSocial?> UpdateAsync(int id, RedSocial redSocial)
    {
        if (id != redSocial.Id) return null;
        _context.Entry(redSocial).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return redSocial;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var redSocial = await GetByIdAsync(id);
        if (redSocial == null) return false;
        _context.RedesSociales.Remove(redSocial);
        await _context.SaveChangesAsync();
        return true;
    }
}
