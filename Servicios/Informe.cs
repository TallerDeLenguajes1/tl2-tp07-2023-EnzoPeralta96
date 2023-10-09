using Models;
namespace Servicios
{
    public class InformeEmpleado
    {
        public int IdEmpleado { get; set; }
        public string NombreEmpledo { get; set; }
        public int CantidadTareas { get; set; }
        public int TareasPendientes { get; set; }
        public int TareasEnproceso { get; set; }
        public int TareasCompleatas { get; set; }
        public double EficienciaEmpleado { get; set; }
    }

    public class Informe
    {
        private readonly List<InformeEmpleado> _informes;
        private readonly AccesoADatosEmpleados _accesoEmpleado;
        private readonly AccesoADatosTareas _accesoTareas;
        private readonly AccesoADatosInforme _accesoInforme;

        public Informe()
        {
            _accesoEmpleado = new AccesoADatosEmpleados();
            _accesoTareas = new AccesoADatosTareas();
            _accesoInforme = new AccesoADatosInforme();
            _informes = new List<InformeEmpleado>();
        }

        private int CantidadTareasXEstado(int idEmpleado, EstadoTarea estado)
        {
            var tareas = _accesoTareas.Obtener();
            return tareas.Count(t => t.Empleado != null && t.Empleado.Id == idEmpleado && t.Estado == estado);
        }
        private int CantidadTareasAsignadas(int idEmpleado)
        {
            return _accesoTareas.Obtener().Count(t => t.Empleado != null  && t.Empleado.Id == idEmpleado);
        }

        public List<InformeEmpleado> GenerarInforme()
        {
            foreach (var empleado in _accesoEmpleado.Obtener())
            {
                var informe = new InformeEmpleado
                {
                    IdEmpleado = empleado.Id,
                    NombreEmpledo = empleado.Nombre,
                    CantidadTareas = CantidadTareasAsignadas(empleado.Id),
                    TareasPendientes = CantidadTareasXEstado(empleado.Id, EstadoTarea.Pendiente),
                    TareasEnproceso = CantidadTareasXEstado(empleado.Id, EstadoTarea.EnProceso),
                    TareasCompleatas = CantidadTareasXEstado(empleado.Id, EstadoTarea.Completada)
                };

                if (informe.CantidadTareas > 0)
                {
                    informe.EficienciaEmpleado = (informe.TareasCompleatas / informe.CantidadTareas) * 100;
                }

                _informes.Add(informe);
            }
            _accesoInforme.Guardar(_informes);
            return _informes;
        }

    }
}