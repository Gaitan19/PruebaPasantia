using Microsoft.AspNetCore.Mvc;
using TareasAPI.Data;
using TareasAPI.Data.TareaModels;

using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TareasAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TareasController: ControllerBase
{
    private readonly GtareasContext _context;

    public TareasController(GtareasContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Tarea> Get()
    {
        var result = _context.Tareas
        .Where(t => (t.EstadoEli & true) == true).ToList();

    return (IEnumerable<Tarea>)result;
    }


//Listamos solo los que estan eliminados
    [HttpGet("deleted")]
    
    public IEnumerable<Tarea>GetDeletedTasks()
    {
         var result = _context.Tareas
        .Where(t => (t.EstadoEli ) == false).ToList();

        return result;
    }
    
 
   //Aqui podemos buscar una tarea en especifico que no este eliminada
    [HttpGet("{id}")]
    public ActionResult<Tarea> GetById(int id)
    {
        var tarea = _context.Tareas.FirstOrDefault(t => t.IdTarea == id && (t.EstadoEli & true) == true);;
        if (tarea is null)
            return NotFound();

        return tarea;      
    }
 

    [HttpGet("deleted/{id}")]
    //Aqui podemos buscar una tarea en especifico que este eliminada
    public ActionResult<Tarea> GetDeletedTasksById(int id)
    {
        var tarea = _context.Tareas.FirstOrDefault(t => t.IdTarea == id && (t.EstadoEli) == false);
        if (tarea is null)
            return NotFound();

        return tarea;      
    }


    [HttpPost]
    public IActionResult Create(Tarea tarea)
    {
        _context.Tareas.Add(tarea);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById), new {id = tarea.IdTarea}, tarea);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Tarea tarea)
    {
        if (id != tarea.IdTarea)
            return BadRequest(); 

        var existingTarea = _context.Tareas.Find(id);
        if(existingTarea is null)
            return NotFound();

        existingTarea.Titulo = tarea.Titulo;
        existingTarea.Estado = tarea.Estado;
        existingTarea.EstadoEli = tarea.EstadoEli;

        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById), new {id = tarea.IdTarea}, tarea);    
        //return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {

        var tarea = _context.Tareas.Find(id);
        if (tarea is null)
            return NotFound();

        if (tarea.EstadoEli == true)
        {
            tarea.EstadoEli = false;
            _context.SaveChanges();
        }    

        return NoContent();
    }


}