using Microsoft.AspNetCore.Mvc;

namespace MiWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PresupuestosController : ControllerBase
{

    [HttpPost("CrearPresupuesto")]
    public IActionResult CrearPresupuesto(Presupuesto presupuesto)
    {
        PresupuestosRepository repoPresupuestos = new PresupuestosRepository();
        repoPresupuestos.CrearPresupuesto(presupuesto);
        return Ok();
    }

    [HttpPost("")]
    public IActionResult AgregarProdAPresupuesto(int idPresupuesto, int idProducto, int cantidad)
    {
        PresupuestosRepository repoPresupuestos = new PresupuestosRepository();
        repoPresupuestos.AgregarProducto(idPresupuesto, idProducto, cantidad);
        return Ok();
    }

    [HttpGet("ObtenerPresupuestos")]
    public ActionResult<List<Presupuesto>> ObtenerPresupuestos()
    {
        PresupuestosRepository repoPresupuestos = new PresupuestosRepository();
        var presupuestos = repoPresupuestos.ObtenerPresupuestos();
        if (presupuestos == null) return BadRequest();
        return Ok(presupuestos);
    }

    [HttpGet("ObtenerPresupuestos/{id}")]
    public ActionResult<Presupuesto> ObtenerPresupuestoPorId(int id)
    {
        PresupuestosRepository repoPresupuestos = new PresupuestosRepository();
        var presupuestos = repoPresupuestos.ObtenerPresupuestoPorId(id);
        if (presupuestos == null) return BadRequest();
        return Ok(presupuestos);
    }

    [HttpDelete]

    public IActionResult BorrarPresupuesto(int id)
    {
        PresupuestosRepository repoPresupuestos = new PresupuestosRepository();
        repoPresupuestos.EliminarPresupuestoPorId(id);
        return Ok();
    }

}