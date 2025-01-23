using Microsoft.AspNetCore.Mvc;
namespace MiWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductoController : ControllerBase
{

    [HttpGet("ObtenerProductos")]
    public ActionResult<List<Producto>> ObtenerProductos(){
        var repo = new ProductoRepository();
        return Ok(repo.ListarProductos());
    }

    [HttpPut("ModificarProducto/{id}")]
    public ActionResult<Producto> ModificarProducto(int id , Producto producto){ 
        var repo = new ProductoRepository();
        repo.ModificarProducto(id,producto);
        return Ok();
    }

    [HttpPost("AgregarProducto")]
    public ActionResult<Producto> CrearProducto(Producto producto){
        var repo = new ProductoRepository();
        repo.CrearProducto(producto);
        return Ok();
    } 

}