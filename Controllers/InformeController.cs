using Microsoft.AspNetCore.Mvc;
using Servicios;
namespace tl2_tp07_2023_EnzoPeralta96.Controllers;


[ApiController]
[Route("[controller]")]

public class InformeController:ControllerBase
{
    private readonly ILogger<AdminTareasController> _logger;
    private readonly Informe _informe;

    public InformeController(ILogger<AdminTareasController> logger)
    {
        _logger = logger;
        _informe = new Informe();
    }

    [HttpGet("GenerarInformeEmpleados")]
    public ActionResult<List<InformeEmpleado>> GenerarInforme()
    {
        var NvoInforme = _informe.GenerarInforme();
        return Ok(NvoInforme);
    }
}