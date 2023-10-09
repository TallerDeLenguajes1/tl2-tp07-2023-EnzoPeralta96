namespace Models;
public class AdministradorEmpleado
{
    private static int _generadorIDEmpleado;
    private AccesoADatosEmpleados _accesoAEmpleados;

    public AdministradorEmpleado()
    {
        _accesoAEmpleados = new AccesoADatosEmpleados();
        if (_generadorIDEmpleado == 0) InicializarGeneradorIdEmpleado();
    }
    private void InicializarGeneradorIdEmpleado()
    {
        var empleados = GetEmpleados();
        int IdMax = empleados.Count > 0 ? empleados.Max(t => t.Id) : 0;
        _generadorIDEmpleado = IdMax + 1;
    }

    public List<Empleado> GetEmpleados()
    {
        return _accesoAEmpleados.Obtener();
    }
    public Empleado GetEmpleado(int id)
    {
        return _accesoAEmpleados.Obtener().FirstOrDefault(e => e.Id == id);
    }

    public Empleado AgregarEmpleado(Empleado empleado)
    {
        var empleados = GetEmpleados();
        empleado.Id = _generadorIDEmpleado;
        empleados.Add(empleado);
        _generadorIDEmpleado++;
        _accesoAEmpleados.Guardar(empleados);
        return empleado;
    }

    public Empleado CambiarDeArea(int idEmpleado, Area nuevaArea)
    {
        var empleados = GetEmpleados();
        var empleado = empleados.FirstOrDefault(e => e.Id == idEmpleado);
        empleado.Area = nuevaArea;
        _accesoAEmpleados.Guardar(empleados);
        return empleado;
    }

    public bool EliminarEmpleado(int idEmpleado)
    {
        bool empleadoEliminado = false;

        var empleados = GetEmpleados();
        var empleadoAEliminar = empleados.FirstOrDefault(e => e.Id == idEmpleado);

        if (empleadoAEliminar != null)
        {
            if (empleados.Remove(empleadoAEliminar))
            {
                _accesoAEmpleados.Guardar(empleados);
                empleadoEliminado = true;
            }
        }
        
        return empleadoEliminado;
    }






}