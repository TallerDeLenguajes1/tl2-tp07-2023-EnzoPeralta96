namespace Models;
public enum EstadoTarea
{
    Pendiente,
    EnProceso,
    Completada
}
public class Tarea
{
    private int _id;
    private string _titulo;
    private string _descripcion;
    private EstadoTarea _estado;
    private Empleado _empleado;

    

    public int Id { get => _id; set => _id = value; }
    public string Titulo { get => _titulo; set => _titulo = value; }
    public string Descripcion { get => _descripcion; set => _descripcion = value; }
    public EstadoTarea Estado { get => _estado; set => _estado = value; }
    public Empleado Empleado { get => _empleado; set => _empleado = value; }
}