using System.Text.Json.Serialization;

namespace GenshinFan_API_REST_ASPNET.Entities;

public class Etiqueta
{
    public int Id { get; set; }
    public string? Nombre { get; set; }

    [JsonIgnore]
    public List<Video>? Videos { get; set; }

    [JsonIgnore]
    public List<Imagen>? Imagenes { get; set; }
}
