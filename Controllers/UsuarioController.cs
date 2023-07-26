using Microsoft.AspNetCore.Mvc;
using EventosApi.Data;

namespace EventosApi.Controllers;

[ApiController]
[Route("usuarios")]
public class UsuarioController : ControllerBase {

    private readonly DatabaseContext db;

    public UsuarioController(DatabaseContext dbContext)
    {
        db = dbContext;
    }

    // GET: /usuarios
    [HttpGet]
    public ActionResult<IEnumerable<Usuario>> GetAllUsuarios([FromQuery] string? sort = "rank_asc")
    {
        // Logic to get all usuarios

        IQueryable<Evento> usuariosQuery = db.Eventos;

        // Handle the 'order' query parameter
        if (sort == null || sort.ToLower() == "rank_asc")
        {
            usuariosQuery = usuariosQuery.OrderBy(e => e.Id); // Sort by 'Id' in ascending order (default)
        }
        else
        {
            usuariosQuery = usuariosQuery.OrderByDescending(e => e.Id); // Sort by 'Id' in descending order
        }

        var usuarios = usuariosQuery.ToList();

        return StatusCode(200, new{usuarios=usuarios});
    }

    // GET: /usuarios/{id}
    [HttpGet("{id}")]
    public ActionResult<string> GetUsuarioById(int id)
    {
        // Logic to get usuario by ID

        // Find the usuario entity with the given ID
        var usuario = db.Usuarios.Find(id);

        if (usuario == null)
        {
            // If no usuario is found with the given ID, return a 404 Not Found response
            return NotFound();
        }

        // If usuario is found, return it as a 200 OK response
        return StatusCode(200, new{usuario=usuario});
    }

    // POST: /usuarios
    [HttpPost]
    public ActionResult<string> CreateUsuario(Usuario usuario)
    {
        // Logic to create a new usuario

        // Add the usuario to the DbContext
        db.Usuarios.Add(usuario);

        // Save the changes to the database
        db.SaveChanges();

        // Return the created usuario with a 201 Created response
        return StatusCode(201, new{usuario=usuario});
    }

    // PUT: /usuarios/{id}
    [HttpPut("{id}")]
    public ActionResult<string> UpdateUsuario(int id, Usuario usuario)
    {
        // Logic to update an existing usuario with the specified ID

        // Find the existing Evento entity with the given ID
        var existingUsuario = db.Usuarios.Find(id);

        if (existingUsuario == null)
        {
            // If no existing evento is found with the given ID, return a 404 Not Found response
            return NotFound();
        }

        // Update the properties of the existing Evento entity with the data from the updatedEvento
        existingUsuario.Email = usuario.Email; // Add other properties to update as needed

        // Save changes to the database
        db.SaveChanges();

        // Return the updated Evento entity as a 200 OK response
        return StatusCode(200, new{usuario=existingUsuario});
    }

    // DELETE: /usuarios/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteUsuario(int id)
    {
        // Logic to delete the usuario with the specified ID

        // Find the usuario entity with the given ID
        var usuario = db.Usuarios.Find(id);

        if (usuario == null)
        {
            // If no usuario is found with the given ID, return a 404 Not Found response
            return NotFound();
        }

        // If usuario is found, remove it from the DbContext and save changes to the database
        db.Usuarios.Remove(usuario);
        db.SaveChanges();

        // Return a 204 No Content response to indicate successful deletion
        return NoContent();
    }
}