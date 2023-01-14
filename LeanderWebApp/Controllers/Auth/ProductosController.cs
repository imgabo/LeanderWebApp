using LeanderWebApp.Data;
using LeanderWebApp.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LeanderWebApp.Controllers.Auth
{
    [EnableCors("corspolicy")]
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductosController : Controller
    {
        private ConsultaProductos consulta =  new ConsultaProductos();

        #region Insertar Producto
        [HttpPost]
        public IActionResult InsertProducto(Producto producto)
        {
            var insert = consulta.InsertProducto(producto);
            return Ok(insert);
        }

        #endregion

        #region Update producto
        [HttpPut]
        public IActionResult UpdateProducto(Producto producto)
        {
            var insert = consulta.UpdateProducto(producto);
            return Ok(insert);
        }
        #endregion

        #region Delete Producto
        [HttpDelete]
        public IActionResult DeleteProducto(int Id)
        {
            var insert = consulta.DeleteProducto(Id);
            return Ok(insert);
        }
        #endregion


    }
}
