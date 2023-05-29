using TareasAPI.Data;
using TareasAPI.Data.TareaModels;
using Microsoft.EntityFrameworkCore;

namespace TareasAPI.Services;

public class TareaService
{
    private readonly GtareasContext _context;

    public TareaService(GtareasContext context)
    {
        _context = context;

    }

    //Metodo para obtener

    public async Task<IEnumerable<Tarea>> GetAll()
    {
       
        return await _context.Tareas.Where(t => (t.EstadoEli & true) == true).ToListAsync();

    }

    public async Task<IEnumerable<Tarea>> GetAllDeletedTasks()
    {
        return await _context.Tareas.Where(t => (t.EstadoEli ) == false).ToListAsync();
    }

    //Metodo para obtener por id

    public async Task<Tarea?> GetByIdTarea(int id)
    {

        return await _context.Tareas.FirstOrDefaultAsync(t => t.IdTarea == id);    
    }


    public async Task<Tarea?> GetById(int id)
    {
      
        return await _context.Tareas.FirstOrDefaultAsync(t => t.IdTarea == id && (t.EstadoEli & true) == true);     
    }

    public async Task<Tarea?> GetDeletedTasksById(int id)
    {
        return await _context.Tareas.FirstOrDefaultAsync(t => t.IdTarea == id && (t.EstadoEli) == false);   
    }

    //Metodo para crear
    public async Task<Tarea?> Create(Tarea newTarea)
    {
        _context.Tareas.Add(newTarea);
        await _context.SaveChangesAsync();

        return newTarea;
        
    }

    //Metodo para Actualizar
    public async Task Update(int id, Tarea tarea)
    { 

        var existingTarea = await GetById(id);
        if(existingTarea is not null)
        {
            existingTarea.Titulo = tarea.Titulo;
            existingTarea.EstadoNoCompletado = tarea.EstadoNoCompletado;
            await _context.SaveChangesAsync();
        }
        
    }

    public async Task Delete(int id)
    {

        var tarea = await _context.Tareas.FindAsync(id);
        if (tarea is not null)
        {
            if (tarea.EstadoEli == true)
            {
                tarea.EstadoEli = false;
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.Tareas.Remove(tarea);
                await _context.SaveChangesAsync();
            }    
        }
        
    }

}