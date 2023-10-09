using Microsoft.AspNetCore.Mvc;
namespace tl2_tp07_2023_EnzoPeralta96.Controllers;
using Models;

[ApiController]
[Route("[controller]")]

public class AdminEmpleadoController : ControllerBase
{
    private readonly ILogger<AdminTareasController> _logger;
    private readonly AdministradorEmpleado _adminEmpleados;

    public AdminEmpleadoController(ILogger<AdminTareasController> logger)
    {
        _logger = logger;
        _adminEmpleados = new AdministradorEmpleado();
    }

    [HttpGet("GetEmpleados")]
    public ActionResult<List<Empleado>> GetEmpleados()
    {
        return Ok(_adminEmpleados.GetEmpleados());

    }
    [HttpGet("GetEmpleadoXId")]
    public ActionResult<Empleado> GetEmpleado(int idEmpleado)
    {
        var empleado = _adminEmpleados.GetEmpleado(idEmpleado);
        if (empleado == null)
        {
            return NotFound("No existe empleado");
        }
        return Ok(empleado);
    }

    [HttpPost("AgregarEmpleado")]
    public ActionResult<Empleado> AgregarEmpleado(Empleado empleado)
    {
        var nuevoEmpleado = _adminEmpleados.AgregarEmpleado(empleado);
        return Ok(nuevoEmpleado);
    }

    [HttpPut("AsignarANuevaArea")]
    public ActionResult<Empleado> AsignarNuevaArea(int idEmpleado, Area nueva)
    {
        if (_adminEmpleados.GetEmpleado(idEmpleado) == null)
        {
            return NotFound("No existe empleado");
        }
        var empleado = _adminEmpleados.CambiarDeArea(idEmpleado,nueva);
        return Ok(empleado);
    }

    [HttpDelete("EliminarEmpleado")]
    public ActionResult<bool> EliminarEmpleado(int idEmpleado)
    {
        if (_adminEmpleados.GetEmpleado(idEmpleado)==null)
        {
            return NotFound("No existe empleado");
        }

        return _adminEmpleados.EliminarEmpleado(idEmpleado) ? Ok(true):BadRequest("Erro al eliminar empleado");
    }

    


    
}
