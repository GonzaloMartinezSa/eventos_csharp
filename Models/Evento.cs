namespace EventosApi;

public class Evento {
    public string Nombre {get; set;}
    public bool Disponible {get;}
    public DateTime FechaCreacion {get;}
    public DateTime FechaFinal {get;}
    public Usuario? Creador {get; set;}
    public OpcionEvento? Opciones {get; set;}
}