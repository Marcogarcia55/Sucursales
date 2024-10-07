
namespace Sucursales.Models{
    public class Empleado{
        public int IdEmpleado { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int IdPuesto { get; set; }
        public int IdSucursal { get; set; }
    }
}