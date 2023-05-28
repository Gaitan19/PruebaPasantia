using Microsoft.AspNetCore.Mvc;
using TareasAPI.Services;
using TareasAPI.Data.TareaModels;
using Microsoft.EntityFrameworkCore;


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
    public async Task<IEnumerable<Tarea>> Get()
    {

        return await _service.GetAll();
    }


//Listamos solo los que estan eliminados
    [HttpGet("deleted")]
    
    public async Task<IEnumerable<Tarea>> GetDeletedTasks()
    {
    
        return await _service.GetAllDeletedTasks();
    }
    
 
   //Aqui podemos buscar una tarea en especifico que no este eliminada
    [HttpGet("{id}")]
    public async Task<ActionResult<Tarea>> GetById(int id)
    {
        var tarea = await _service.GetById(id);
        if (tarea is null)
            return TareaNotFound(id);

        return tarea;      
    }
 

    [HttpGet("deleted/{id}")]
    //Aqui podemos buscar una tarea en especifico que este eliminada
    public async Task<ActionResult<Tarea>> GetDeletedTasksById(int id)
    {
        var tarea = await _service.GetDeletedTasksById(id);
        if (tarea is null)
            return TareaNotFound(id);

        return tarea;      
    }


    [HttpPost]
    public async Task< IActionResult> Create(Tarea tarea)
    {
       var newTarea = await _service.Create(tarea);

        return CreatedAtAction(nameof(GetById), new {id = tarea.IdTarea}, newTarea);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Tarea tarea)
    {
        if (id != tarea.IdTarea)
            return BadRequest(new {message = $"El ID({id}) no coincide con el ID({tarea.IdTarea}) del cuerpo de la solicitud"}); 

        var TareaUpdate = await _service.GetById(id);

        if (TareaUpdate is not null)
        {
           await _service.Update(id,tarea);
            return NoContent();
        } 
        else
        {
            return TareaNotFound(id);
        } 
        //return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {

        

        var TareaDelete = await _service.GetByIdTarea(id);

        if (TareaDelete is not null)
        {
            await _service.Delete(id);
            return NoContent();
        } 
        else
        {
            return TareaNotFound(id);
        } 
    }


    public NotFoundObjectResult TareaNotFound(int id)
    {
        return NotFound(new {message = $"La tarea con ID = {id} no existe"});
        
    }

}