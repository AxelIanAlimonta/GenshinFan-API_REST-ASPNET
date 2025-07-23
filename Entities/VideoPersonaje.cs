namespace GenshinFan_API_REST_ASPNET.Entities;

public class VideoPersonaje
{
    public int Id { get; set; }
    public string? Titulo { get; set; }
    public string? Url { get; set; }
    public DateTime? FechaPublicacion { get; set; }
    public int PersonajeId { get; set; }
    public Personaje? Personaje { get; set; }


}
