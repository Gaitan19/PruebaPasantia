using TareasAPI.Data;
using TareasAPI.Data.TareaModels;


namespace TareasAPI.Services;

public class TareaService
{
    private readonly GtareasContext _context;

    public TareaService(GtareasContext context)
    {
        _context = context;

    }

    //Metodo para obtener

    public IEnumerable<Tarea> GetAll()
    {
        var result = _context.Tareas
        .Where(t => (t.EstadoEli & true) == true).ToList();

    return (IEnumerable<Tarea>)result;
    }

    public IEnumerable<Tarea>GetAllDeletedTasks()
    {
         var result = _context.Tareas
        .Where(t => (t.EstadoEli ) == false).ToList();

        return result;
    }

    //Metodo para obtener por id

    public Tarea? GetByIdTarea(int id)
    {
        var tarea = _context.Tareas.FirstOrDefault(t => t.IdTarea == id);
        
        return tarea;      
    }


    public Tarea? GetById(int id)
    {
        var tarea = _context.Tareas.FirstOrDefault(t => t.IdTarea == id && (t.EstadoEli & true) == true);
        
        return tarea;      
    }

    public Tarea? GetDeletedTasksById(int id)
    {
        var tarea = _context.Tareas.FirstOrDefault(t => t.IdTarea == id && (t.EstadoEli) == false);

        return tarea;      
    }

    //Metodo para crear
    public Tarea Create(Tarea newTarea)
    {
        _context.Tareas.Add(newTarea);
        _context.SaveChanges();

        return newTarea;
        
    }

    //Metodo para Actualizar
    public void Update(int id, Tarea tarea)
    { 

        var existingTarea = GetById(id);
        if(existingTarea is not null)
        {
            existingTarea.Titulo = tarea.Titulo;
            existingTarea.Estado = tarea.Estado;
            existingTarea.EstadoEli = tarea.EstadoEli;
            _context.SaveChanges();
        }
        
    }

    public void Delete(int id)
    {

        var tarea = _context.Tareas.Find(id);
        if (tarea is not null)
        {
            if (tarea.EstadoEli == true)
            {
                tarea.EstadoEli = false;
                _context.SaveChanges();
            }
            else
            {
                _context.Tareas.Remove(tarea);
                _context.SaveChanges();
            }    
        }
        
    }

}