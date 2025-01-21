public class Presupuesto
{
    int idPresupuesto;
    string nombreDestinatario;
    List<PresupuestosDetalle> detalle;
    DateTime fechaCreacion;

    public Presupuesto(int idPresupuesto, string nombreDestinatario, List<PresupuestosDetalle> detalle, DateTime fechaCreacion)
    {
        this.idPresupuesto = idPresupuesto;
        this.nombreDestinatario = nombreDestinatario;
        this.detalle = new List<PresupuestosDetalle> ();
        this.fechaCreacion = fechaCreacion;
    }

    void MontoPresupuesto()
    {

    }
    void MontoPresupuestoConIva()
    {

    }

    void CantidadProductos()
    {

    }
}