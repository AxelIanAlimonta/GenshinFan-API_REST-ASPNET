namespace GenshinFan_API_REST_ASPNET.Entities;

public class Etiqueta
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public List<Video>? Videos { get; set; }
    public List<Imagen>? Imagenes { get; set; }
}
