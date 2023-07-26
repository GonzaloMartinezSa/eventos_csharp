using Microsoft.AspNetCore.Mvc;
using EventosApi.Data;

namespace EventosApi.Controllers;

[ApiController]
[Route("eventos")]
public class EventoController : ControllerBase {

    private readonly DatabaseContext db;

    public EventoController(DatabaseContext dbContext)
    {
        db = dbContext;
    }

    // GET: /eventos
    [HttpGet]
    public ActionResult<IEnumerable<Evento>> GetAllEventos([FromQuery] string? sort = "rank_asc")
    {
        // Logic to get all eventos

        IQueryable<Evento> eventosQuery = db.Eventos;

        // Handle the 'order' query parameter
        if (sort == null || sort.ToLower() == "rank_asc")
        {
            eventosQuery = eventosQuery.OrderBy(e => e.Id); // Sort by 'Id' in ascending order (default)
        }
        else
        {
            eventosQuery = eventosQuery.OrderByDescending(e => e.Id); // Sort by 'Id' in descending order
        }

        var eventos = eventosQuery.ToList();

        return StatusCode(200, new{eventos=eventos});
    }

    // GET: /eventos/{id}
    [HttpGet("{id}")]
    public ActionResult<Evento> GetEventoById(int id)
    {
        // Logic to get evento by ID

        // Find the Evento entity with the given ID
        var evento = db.Eventos.Find(id);

        if (evento == null)
        {
            // If no evento is found with the given ID, return a 404 Not Found response
            return NotFound();
        }

        // If evento is found, return it as a 200 OK response
        return StatusCode(200, new{evento=evento});
    }

    // POST: /eventos
    [HttpPost]
    public ActionResult<string> CreateEvento([FromBody] Evento evento)
    {
        // Logic to create a new evento

        // Add the evento to the DbContext
        db.Eventos.Add(evento);

        // Save the changes to the database
        db.SaveChanges();

        // Return the created evento with a 201 Created response
        return StatusCode(201, new{evento=evento});
    }

    // PUT: /eventos/{id}
    [HttpPut("{id}")]
    public ActionResult<string> UpdateEvento(int id, [FromBody] Evento evento)
    {
        // Logic to update an existing evento with the specified ID

        // Find the existing Evento entity with the given ID
        var existingEvento = db.Eventos.Find(id);

        if (existingEvento == null)
        {
            // If no existing evento is found with the given ID, return a 404 Not Found response
            return NotFound();
        }

        // Update the properties of the existing Evento entity with the data from the updatedEvento
        existingEvento.Nombre = evento.Nombre; // Add other properties to update as needed

        // Save changes to the database
        db.SaveChanges();

        // Return the updated Evento entity as a 200 OK response
        return StatusCode(200, new{evento=existingEvento});
    }

    // DELETE: /eventos/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteEvento(int id)
    {
        // Logic to delete the evento with the specified ID

        // Find the Evento entity with the given ID
        var evento = db.Eventos.Find(id);

        if (evento == null)
        {
            // If no evento is found with the given ID, return a 404 Not Found response
            return NotFound();
        }

        // If evento is found, remove it from the DbContext and save changes to the database
        db.Eventos.Remove(evento);
        db.SaveChanges();

        // Return a 204 No Content response to indicate successful deletion
        return NoContent();
    }
}