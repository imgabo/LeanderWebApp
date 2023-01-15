using LeanderWebApp.Data;
using LeanderWebApp.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LeanderWebApp.Controllers
{
    [EnableCors("corspolicy")]
    [ApiController]
    [Route("[controller]/[action]")]
    public class EstadosController : Controller
    {
        private ConsultaEstados consulta = new ConsultaEstados();

        #region Obtener Estados
        [HttpGet]
        public IActionResult getEstados()
        {
            var data = consulta.getEstados();
            return Ok(data);
        }
        #endregion
        #region Insertar Estados
        [HttpPost]
        public IActionResult InsertEstados(Estado estado)
        {
            var insert = consulta.InsertEstados(estado);
            return Ok(insert);
        }
        #endregion

        #region Actualizar Estados
        [HttpPut]
        public IActionResult UpdateEstados(Estado estado)
        {
            var update = consulta.UpdateEstados(estado);
            return Ok(update);
        }
        #endregion

        #region Eliminar Estados por id
        [HttpDelete]
        public IActionResult DeleteEstados(int id)
        {
            var delete = consulta.DeleteEstados(id);
            return Ok(delete);
        }
        #endregion
    }
}
