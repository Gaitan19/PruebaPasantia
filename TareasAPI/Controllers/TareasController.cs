using Microsoft.AspNetCore.Mvc;
using TareasAPI.Services;
using TareasAPI.Data.TareaModels;



namespace TareasAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TareasController: ControllerBase
{
    private readonly TareaService _service;

    public TareasController(TareaService service)
    {
        _service = service;
    }

    [HttpGet]
    public IEnumerable<Tarea> Get()
    {

        return _service.GetAll();
    }


//Listamos solo los que estan eliminados
    [HttpGet("deleted")]
    
    public IEnumerable<Tarea>GetDeletedTasks()
    {
    
        return _service.GetAllDeletedTasks();
    }
    
 
   //Aqui podemos buscar una tarea en especifico que no este eliminada
    [HttpGet("{id}")]
    public ActionResult<Tarea> GetById(int id)
    {
        var tarea = _service.GetById(id);
        if (tarea is null)
            return NotFound();

        return tarea;      
    }
 

    [HttpGet("deleted/{id}")]
    //Aqui podemos buscar una tarea en especifico que este eliminada
    public ActionResult<Tarea> GetDeletedTasksById(int id)
    {
        var tarea = _service.GetDeletedTasksById(id);
        if (tarea is null)
            return NotFound();

        return tarea;      
    }


    [HttpPost]
    public IActionResult Create(Tarea tarea)
    {
       var newTarea = _service.Create(tarea);

        return CreatedAtAction(nameof(GetById), new {id = tarea.IdTarea}, newTarea);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Tarea tarea)
    {
        if (id != tarea.IdTarea)
            return BadRequest(); 

        var TareaUpdate = _service.GetById(id);

        if (TareaUpdate is not null)
        {
            _service.Update(id,tarea);
            return NoContent();
        } 
        else
        {
            return NotFound();
        } 
        //return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {

        

        var TareaDelete = _service.GetByIdTarea(id);

        if (TareaDelete is not null)
        {
            _service.Delete(id);
            return NoContent();
        } 
        else
        {
            return NotFound();
        } 
    }


}