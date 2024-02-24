using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using L01_2021AR601_2021MM656.models;
using Microsoft.EntityFrameworkCore;

namespace L01_2021AR601_2021MM656.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class calificacionesController : ControllerBase
    {
        private readonly blogContext _blogContext;
        public calificacionesController(blogContext blogContext)
        {
            _blogContext = blogContext;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<calificaciones> ListadoCalificaciones = (from e in _blogContext.calificaciones
                                                    select e).ToList();
            if (ListadoCalificaciones.Count == 0)
            { return NotFound(); }

            return Ok(ListadoCalificaciones);

        }





        //crear

        [HttpPost]
        [Route("add")]
        public IActionResult GuardarEquipo([FromBody] calificaciones calificaciones)
        {
            try

            {

                _blogContext.calificaciones.Add(calificaciones);
                _blogContext.SaveChanges();

                return Ok(calificaciones);

            }

            catch (Exception ex)

            {
                return BadRequest(ex.Message);
            }


        }


        //modificar

        [HttpPut]
        [Route("actualizar/{id}")]
        public ActionResult ActualizarEquipo(int id, [FromBody] calificaciones calificacionModificar)
        {
            calificaciones? calificacionActual = (from e in _blogContext.calificaciones where e.calificacionId == id select e).FirstOrDefault();

            if (calificacionActual == null)
            {
                return NotFound();
            }

            calificacionActual.publicacionId = calificacionModificar.publicacionId;
            calificacionActual.usuarioId = calificacionModificar.usuarioId;
            calificacionActual.calificacion = calificacionModificar.calificacion;


            _blogContext.Entry(calificacionActual).State = EntityState.Modified;

            _blogContext.SaveChanges();

            return Ok(calificacionActual);
        }

        [HttpDelete]
        [Route("eliminar/{id}")]
        public ActionResult EliminarEquipo(int id)
        {
            calificaciones? calificaciones = (from e in _blogContext.calificaciones where e.calificacionId == id select e).FirstOrDefault();

            // Verificamos que exista el registro según su ID
            if (calificaciones == null)
            {
                return NotFound();
            }

            _blogContext.calificaciones.Attach(calificaciones);
            _blogContext.calificaciones.Remove(calificaciones);
            _blogContext.SaveChanges();

            return Ok(calificaciones);
        }
    }
}
