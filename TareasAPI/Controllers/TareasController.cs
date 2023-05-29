using Microsoft.AspNetCore.Mvc;
using TareasAPI.Services;
using TareasAPI.Data.TareaModels;

using Microsoft.AspNetCore.Authorization;

using Swashbuckle.AspNetCore.Annotations;
namespace TareasAPI.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TareasController: ControllerBase
{
    private readonly TareaService _service;

    public TareasController(TareaService service)
    {
        _service = service;
    }

    
    [HttpGet("getall")]
    [SwaggerOperation("Obtiene todas las tareas")]
    public async Task<IEnumerable<Tarea>> Get()
    {

        return await _service.GetAll();
    }


    //Aqui podemos buscar una tarea en especifico que no este eliminada
    [HttpGet("getall/{id}")]
    public async Task<ActionResult<Tarea>> GetById(int id)
    {
        var tarea = await _service.GetById(id);
        if (tarea is null)
            return TareaNotFound(id);

        return tarea;      
    }


//Listamos solo los que estan eliminados
    [HttpGet("getalldeleted")]
    
    public async Task<IEnumerable<Tarea>> GetDeletedTasks()
    {
    
        return await _service.GetAllDeletedTasks();
    }
    
 

    [HttpGet("getalldeleted/{id}")]
    //Aqui podemos buscar una tarea en especifico que este eliminada
    public async Task<ActionResult<Tarea>> GetDeletedTasksById(int id)
    {
        var tarea = await _service.GetDeletedTasksById(id);
        if (tarea is null)
            return TareaNotFound(id);

        return tarea;      
    }

    [Authorize(Policy = "SuperAdmin")]
    [HttpPost("create")]
    [SwaggerOperation("Crea una nueva tarea")]
    public async Task< IActionResult> Create(Tarea tarea)
    {
       var newTarea = await _service.Create(tarea);

        return CreatedAtAction(nameof(GetById), new {id = tarea.IdTarea}, newTarea);
    }

    [Authorize(Policy = "SuperAdmin")]
    [HttpPut("update/{id}")]
     [SwaggerOperation("Actualiza una tarea existente")]
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

    [Authorize(Policy = "SuperAdmin")]
    [HttpDelete("delete/{id}")]
    [SwaggerOperation("Elimina una tarea")]
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

    [HttpGet]
    public NotFoundObjectResult TareaNotFound(int id)
    {
        return NotFound(new {message = $"La tarea con ID = {id} no existe"});
        
    }

}