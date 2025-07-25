using System.ComponentModel.DataAnnotations;

namespace GenshinFan_API_REST_ASPNET.Entities;

public class Imagen
{
    public int Id { get; set; }

    public string? Url { get; set; }

    public int? Calificacion { get; set; }

    public int? PersonajeId { get; set; }
    public Personaje? Personaje { get; set; }
    public List<Etiqueta>? Etiquetas { get; set; }
}
