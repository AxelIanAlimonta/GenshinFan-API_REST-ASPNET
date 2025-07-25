using Microsoft.EntityFrameworkCore;
using GenshinFan_API_REST_ASPNET.Entities;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }



    public DbSet<Elemento> Elementos { get; set; }
    public DbSet<Region> Regiones { get; set; }
    public DbSet<Personaje> Personajes { get; set; }
    public DbSet<Imagen> Imagenes { get; set; }
    public DbSet<Video> Videos { get; set; }
    public DbSet<Animacion> Animaciones { get; set; }
    public DbSet<TipoAnimacion> TiposAnimaciones { get; set; }
    public DbSet<Etiqueta> Etiquetas { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Personaje>()
            .Property(p => p.FechaLanzamiento)
            .HasColumnType("date");
    }

}
