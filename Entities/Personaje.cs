namespace GenshinFan_API_REST_ASPNET.Entities;

public class Personaje
{

    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public int? Rareza { get; set; }
    public string? AvatarURL { get; set; }
    public string? SplashArtURL { get; set; }
    public string? TarjetaURL { get; set; }

    public DateTime? FechaLanzamiento { get; set; }

    public int? ElementoId { get; set; }
    public Elemento? Elemento { get; set; }

    public int? RegionId { get; set; }
    public Region? Region { get; set; }

    public ICollection<ImagenPersonaje>? Imagenes { get; set; }
    public ICollection<VideoPersonaje>? Videos { get; set; }

}
