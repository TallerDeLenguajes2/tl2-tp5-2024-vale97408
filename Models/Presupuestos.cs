public class Presupuesto
{
    int idPresupuesto;
    string nombreDestinatario;
    List<PresupuestosDetalle> detalles;
    DateTime fechaCreacion;


    public int IdPresupuesto { get => idPresupuesto; set => idPresupuesto = value; }
    public string NombreDestinatario { get => nombreDestinatario; set => nombreDestinatario = value; }
    public List<PresupuestosDetalle> Detalles { get => detalles; set => detalles = value; }
    public DateTime FechaCreacion { get => fechaCreacion; set => fechaCreacion = value; }

    public Presupuesto()
    {

    }

    public Presupuesto(int idPresupuesto, string nombreDestinatario, List<PresupuestosDetalle> detalles, DateTime fechaCreacion)
    {
        this.IdPresupuesto = idPresupuesto;
        this.NombreDestinatario = nombreDestinatario;
        this.Detalles = new List<PresupuestosDetalle>();
        this.FechaCreacion = fechaCreacion;
    }

    public Presupuesto(int idPresupuesto, string nombreDestinatario, DateTime fechaCreacion)
    {
        this.IdPresupuesto = idPresupuesto;
        this.NombreDestinatario = nombreDestinatario;
        this.FechaCreacion = fechaCreacion;
        this.Detalles = new List<PresupuestosDetalle>(); // Para evitar el error
    }



    public double MontoPresupuesto()
    {
        double monto = 0;
        foreach (var det in detalles)
        {
            monto += det.Producto.Precio * det.Cantidad;
        }

        return monto;

    }

    public double MontoPresupuestoConIva()
    {
        return MontoPresupuesto() * 1.21;
    }

    public int CantidadProductos()
    {
        int cant = 0;
        foreach (var det in detalles)
        {
            cant += det.Cantidad;
        }
        return cant;
    }
}