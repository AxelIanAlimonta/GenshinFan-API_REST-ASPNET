using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GenshinFan_API_REST_ASPNET.Entities;

public class Imagen
{
    public int Id { get; set; }

    public string? Url { get; set; }

    public int? Calificacion { get; set; }

    public int? PersonajeId { get; set; }

    [JsonIgnore]
    public Personaje? Personaje { get; set; }

    [JsonIgnore]
    public List<Etiqueta>? Etiquetas { get; set; }
}
