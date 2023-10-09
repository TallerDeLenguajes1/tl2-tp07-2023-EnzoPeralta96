using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace tl2_tp07_2023_EnzoPeralta96.Controllers;

[ApiController]
[Route("[controller]")]
public class AdminTareasController : ControllerBase
{
    private readonly ILogger<AdminTareasController> _logger;
    private readonly AdministradorTarea _adminTareas;

    public AdminTareasController(ILogger<AdminTareasController> logger)
    {
        _logger = logger;
        _adminTareas = new AdministradorTarea();
    }

    [HttpGet("GetTareas")]
    public ActionResult<List<Tarea>> ListarTareas()
    {
        var tareas = _adminTareas.ListarTareas();
        return Ok(tareas);
    }

    [HttpGet("GetTareasCompletadas")]
    public ActionResult<List<Tarea>> ListarTareasCompletadas()
    {
        var tareasCompletadas = _adminTareas.ListarTareasCompletadas();
        return Ok(tareasCompletadas);
    }

    [HttpGet("GetTareaXId")]
    public ActionResult<Tarea> GetTarea(int id)
    {
        var tarea = _adminTareas.GetTarea(id);
        if (tarea == null)
        {
            return NotFound("No existe tarea");
        }else
        {
            return Ok(tarea);
        }
    }


    [HttpPost("CrearTarea")]
    public ActionResult<Tarea> CrearTarea(Tarea tarea)
    {
        var nuevaTarea = _adminTareas.CrearTarea(tarea);
        return Ok(nuevaTarea);
    }

    [HttpPut("ActualizarTarea")]
    public ActionResult<Tarea> ActualizarTarea(Tarea tarea, int id)
    {
        if (_adminTareas.GetTarea(id) == null)
        {
            return NotFound("No existe tarea");
        }
        var tareaActualizada = _adminTareas.Actualizar(tarea,id);
        return Ok(tareaActualizada);
        
        /*if (admin.Actualizar(tarea,id))
        {
            return Ok(tarea);
        }else
        {
            return NotFound("No existe");
        }*/
    }

    [HttpPut("ActualizarEstado")]
    public ActionResult<Tarea> ActualizarEstado(int idTarea, EstadoTarea nuevo)
    {
        if (_adminTareas.GetTarea(idTarea) == null)
        {
            return NotFound("No existe tarea");
        }
        var tareaActualizada = _adminTareas.CambiarEstado(idTarea,nuevo);
        return Ok(tareaActualizada);
    }

    [HttpPut("AsignarEmpleado")]
    public ActionResult<Tarea> AsignarEmpleadoATarea(int idTarea,int idEmpleado)
    {
        var adminEmpleado = new AdministradorEmpleado();
        if (adminEmpleado.GetEmpleado(idEmpleado)== null)
        {
            return NotFound("No existe empleado");
        }
        if (_adminTareas.GetTarea(idTarea) == null)
        {
            return NotFound("No existe tarea");
        }
        var tareaConEmpleadoAsignado = _adminTareas.AsignarEmpleado(idTarea,idEmpleado);
        return Ok(tareaConEmpleadoAsignado);
    }

    [HttpDelete("EliminarTarea")]
    public ActionResult<bool> EliminarTarea(int id)
    {
        if (_adminTareas.GetTarea(id) == null)
        {
            return NotFound("No existe tarea");
        }

        if (_adminTareas.EliminarTarea(id))
        {
            return Ok(true);
        }else
        {
            return Ok(false);
        }   
    }


   
}
