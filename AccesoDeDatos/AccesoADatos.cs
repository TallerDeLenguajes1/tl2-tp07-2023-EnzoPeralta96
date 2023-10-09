using System.Text.Json;
using Models;
using Servicios;

abstract public class ManejoArchivos
{
    protected bool ExisteArchivo(string rutaArchivo)
    {
        if (File.Exists(rutaArchivo))
        {
            var info = new FileInfo(rutaArchivo);

            if (info.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

}

public class AccesoADatosTareas : ManejoArchivos
{
    private string datosTareas = "ArchivosJson/tareas.json";

    public List<Tarea> Obtener()
    {
        var tareas = new List<Tarea>();
        if (ExisteArchivo(datosTareas))
        {
            string TextoJson = File.ReadAllText(datosTareas);
            tareas = JsonSerializer.Deserialize<List<Tarea>>(TextoJson);
        }
        return tareas;
    }

    public void Guardar(List<Tarea> tareas)
    {
        string formatoJson = JsonSerializer.Serialize(tareas);
        File.WriteAllText(datosTareas, formatoJson);
    }
}

public class AccesoADatosEmpleados : ManejoArchivos
{
    private string datosEmpleados = "ArchivosJson/empleados.json";

    public List<Empleado> Obtener()
    {
        var empleados = new List<Empleado>();
        if (ExisteArchivo(datosEmpleados))
        {
            string TextoJson = File.ReadAllText(datosEmpleados);
            empleados = JsonSerializer.Deserialize<List<Empleado>>(TextoJson);
        }
        return empleados;
    }

    public void Guardar(List<Empleado> empleados)
    {
        string formatoJson = JsonSerializer.Serialize(empleados);
        File.WriteAllText(datosEmpleados, formatoJson);
    }
}

public class AccesoADatosInforme:ManejoArchivos
{
    private string datosInforme = "ArchivosJson/informe.json";
    public void Guardar(List<InformeEmpleado> informes)
    {
        string formatoJson = JsonSerializer.Serialize(informes);
        File.WriteAllText(datosInforme, formatoJson);
    }
}


