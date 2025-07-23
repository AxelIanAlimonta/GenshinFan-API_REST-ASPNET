namespace GenshinFan_API_REST_ASPNET.Entities;

public class Animacion
{
    public int Id { get; set; }
    public string? Url { get; set; }

    public int? TipoAnimacionId { get; set; }
    public TipoAnimacion? TipoAnimacion { get; set; }

    public int? PersonajeId { get; set; }
    public Personaje? Personaje { get; set; }

}
