using LeanderWebApp.Data;
using LeanderWebApp.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LeanderWebApp.Controllers
{
    [EnableCors("corspolicy")]
    [ApiController]
    [Route("[controller]/[action]")]
    public class LocalidadesController : Controller
    {
        private ConsultaLocalidades consulta = new ConsultaLocalidades();


        #region Obtener Localidades
        [HttpGet]
        public IActionResult getLocalidades()
        {
            var data = consulta.getLocalidades();
            return Ok(data);
        }
        #endregion
        #region Insertar Localidad
        [HttpPost]
        public IActionResult InsertLocalidad(Localidad localidad)
        {
            var insert = consulta.InsertLocalidad(localidad);
            return Ok(insert);
        }
        #endregion

        #region Actualizar Localidad
        [HttpPut]
        public IActionResult UpdateLocalidad(Localidad localidad)
        {
            var update = consulta.UpdateLocalidad(localidad);
            return Ok(update);
        }
        #endregion

        #region Eliminar Localidad por id
        [HttpDelete]
        public IActionResult DeleteLocalidad(int id)
        {
            var delete = consulta.DeleteLocalidad(id);
            return Ok(delete);
        }
        #endregion
    }
}
