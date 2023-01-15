using LeanderWebApp.Data;
using LeanderWebApp.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LeanderWebApp.Controllers
{
    [EnableCors("corspolicy")]
    [ApiController]
    [Route("[controller]/[action]")]
    public class CategoriasController : Controller
    {
        private ConsultaCategorias consulta = new ConsultaCategorias();


        #region Obtener categorias
        [HttpGet]
        public IActionResult getCategorias()
        {
            var data = consulta.getCategorias();
            return Ok(data);
        }
        #endregion
        #region Insertar categoria
        [HttpPost]
        public IActionResult InsertCategoria(Categoria categoria)
        {
            var insert = consulta.InsertCategoria(categoria);
            return Ok(insert);
        }
        #endregion

        #region Actualizar Categoria
        [HttpPut]
        public IActionResult UpdateCategoria(Categoria categoria)
        {
            var update = consulta.UpdateCategoria(categoria);
            return Ok(update);  
        }
        #endregion

        #region Eliminar categoria por id
        [HttpDelete]
        public IActionResult DeleteCategoria(int id)
        {
            var delete = consulta.DeleteCategoria(id);
            return Ok(delete);  
        }
        #endregion
    }
}
