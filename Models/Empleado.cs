namespace Models;
public enum Area
{
    BackEnd,
    FrontEnd,
    Segurity,
    Testing,

}
public class Empleado
{
    int _id;
    string _nombre;
    Area _area;
    public int Id { get => _id; set => _id = value; }
    public string Nombre { get => _nombre; set => _nombre = value; }
    public Area Area { get => _area; set => _area = value; }
}