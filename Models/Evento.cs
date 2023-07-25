namespace EventosApi;

public class Evento {
    public string Nombre {get; set;}
    public bool Disponible;
    public DateTime FechaCreacion;
    public DateTime FechaFinal;
    public Usuario Creador;
    public OpcionEvento Opciones;
}