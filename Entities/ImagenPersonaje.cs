using System.ComponentModel.DataAnnotations;

namespace GenshinFan_API_REST_ASPNET.Entities;

public class ImagenPersonaje
{
    public int Id { get; set; }

    public string? Url { get; set; }

    public int? Calificacion { get; set; }

    public int PersonajeId { get; set; }
    public Personaje? Personaje { get; set; }
}
