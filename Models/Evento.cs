namespace EventosApi;

public class Evento {
    public int Id {get; set;}
    public string Nombre {get; set;}
    public bool Disponible {get;}
    public DateTime FechaCreacion {get;}
    public DateTime FechaFinal {get;}
    public virtual Usuario? Creador {get; set;}
    public ICollection<OpcionEvento>? Opciones { get; set; }
}