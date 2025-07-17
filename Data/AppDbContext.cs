using Microsoft.EntityFrameworkCore;
using GenshinFan_API_REST_ASPNET.Entities;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Elemento> Elementos { get; set; }
}
