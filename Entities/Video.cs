using System.Text.Json.Serialization;

namespace GenshinFan_API_REST_ASPNET.Entities;

public class Video
{
    public int Id { get; set; }
    public string? Titulo { get; set; }
    public string? Url { get; set; }
    public DateTime? FechaPublicacion { get; set; }


    public int? PersonajeId { get; set; }
    [JsonIgnore]
    public Personaje? Personaje { get; set; }


    public List<Etiqueta>? Etiquetas { get; set; }
}
