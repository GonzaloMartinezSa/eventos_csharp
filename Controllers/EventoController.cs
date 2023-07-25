using Microsoft.AspNetCore.Mvc;

namespace EventosApi.Controllers;

[ApiController]
[Route("eventos")]
public class EventoController : ControllerBase {

    // GET: /evento
    [HttpGet]
    public ActionResult<IEnumerable<string>> GetAllEventos()
    {
        // Logic to get all eventos
        var eventos = new List<string>{"Evento 1", "Evento 2", "Evento 3"};
        return StatusCode(200, new{eventos=eventos});
    }

    // GET: /evento/{id}
    [HttpGet("{id}")]
    public ActionResult<string> GetEventoById(int id)
    {
        // Logic to get evento by ID
        return $"Evento with ID: {id}";
    }

    // POST: /evento
    [HttpPost]
    public ActionResult<string> CreateEvento(Evento evento)
    {
        // Logic to create a new evento
        return $"Created evento: {evento.Nombre}";
    }

    // PUT: /evento/{id}
    [HttpPut("{id}")]
    public ActionResult<string> UpdateEvento(int id, Evento evento)
    {
        // Logic to update an existing evento with the specified ID
        return $"Updated evento with ID {id} to: {evento.Nombre}";
    }

    // DELETE: /evento/{id}
    [HttpDelete("{id}")]
    public ActionResult<string> DeleteEvento(int id)
    {
        // Logic to delete the evento with the specified ID
        return $"Deleted evento with ID: {id}";
    }
}