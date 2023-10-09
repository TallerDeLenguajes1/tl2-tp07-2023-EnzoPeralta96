namespace Models;
public class AdministradorTarea
{
    private static int _generadorIDTarea;
    private AccesoADatosTareas _accesoATareas;
   
    public AdministradorTarea()
    {
        _accesoATareas = new AccesoADatosTareas();
        if (_generadorIDTarea == 0) InicializarGeneradorIdTarea();
    }

    private void InicializarGeneradorIdTarea()
    {
        var tareas = ListarTareas();
        int IdMax = tareas.Count > 0 ? tareas.Max(t => t.Id) : 0;
        _generadorIDTarea = IdMax + 1;
    }
    public List<Tarea> ListarTareas()
    {
        return _accesoATareas.Obtener();
    }

    /* public List<Tarea> ListarTareasCompletadas()
     {
         return ListarTareas().FindAll(tarea => tarea.Estado == EstadoTarea.Completada);
     }*/

    public List<Tarea> ListarTareasCompletadas()
    {
        return ListarTareas().Where(tarea => tarea.Estado == EstadoTarea.Completada).ToList();
    }

    public Tarea GetTarea(int id)
    {
        return ListarTareas().FirstOrDefault(tarea => tarea.Id == id);
    }

    public Tarea CrearTarea(Tarea tarea)
    {
        var tareas = ListarTareas();
        tarea.Id = _generadorIDTarea;
        tareas.Add(tarea);
        _generadorIDTarea++;
        _accesoATareas.Guardar(tareas);
        return tarea;
    }

    public Tarea Actualizar(Tarea tareaActualizada, int id)
    {
        var tareas = ListarTareas();
        var tareaLocal = tareas.FirstOrDefault(t => t.Id == id);
        if (tareaLocal != null)
        {
            tareaLocal.Titulo = tareaActualizada.Titulo;
            tareaLocal.Descripcion = tareaActualizada.Descripcion;
            tareaLocal.Estado = tareaActualizada.Estado;
            tareaLocal.Empleado = tareaActualizada.Empleado;
            _accesoATareas.Guardar(tareas);
        }
        return tareaLocal;
    }

    public Tarea CambiarEstado(int idTarea, EstadoTarea nuevoEstado)
    {
        var tareas = ListarTareas();
        var tarea = tareas.FirstOrDefault(t => t.Id == idTarea);
        tarea.Estado = nuevoEstado;
        _accesoATareas.Guardar(tareas);
        return tarea;
    }
    public bool EliminarTarea(int id)
    {
        bool tareaEliminada = false;

        var tareas = ListarTareas();
        var tareaAEliminar = tareas.FirstOrDefault(t => t.Id == id);

        if (tareaAEliminar != null)
        {
            tareaEliminada = tareas.Remove(tareaAEliminar);

            if (tareaEliminada)
            {
                _accesoATareas.Guardar(tareas);
            }
        }

        return tareaEliminada;
    }

    public Tarea AsignarEmpleado(int idTarea, int idEmpleado)
    {
        var tareas = ListarTareas();
        var adminEmpleados = new AdministradorEmpleado();

        var tareaAsignar = tareas.FirstOrDefault(t => t.Id==idTarea);
        tareaAsignar.Empleado = adminEmpleados.GetEmpleado(idEmpleado);
        
        _accesoATareas.Guardar(tareas);
        return tareaAsignar;
    }

    

    







}