using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using L01_2021AR601_2021MM656.models;
using Microsoft.EntityFrameworkCore;

namespace L01_2021AR601_2021MM656.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class comentariosController : ControllerBase
    {
        private readonly blogContext _blogContext;
        public comentariosController(blogContext blogContext)
        {
            _blogContext = blogContext;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<comentarios> ListadoComentarios = (from e in _blogContext.comentarios
                                           select e).ToList();
            if (ListadoComentarios.Count == 0)
            { return NotFound(); }

            return Ok(ListadoComentarios);

        }
        




        //crear

        [HttpPost]
        [Route("add")]
        public IActionResult GuardarEquipo([FromBody] comentarios comentarios)
        {
            try

            {

                _blogContext.comentarios.Add(comentarios);
                _blogContext.SaveChanges();

                return Ok(comentarios);

            }

            catch (Exception ex)

            {
                return BadRequest(ex.Message);
            }


        }


        //modificar

        [HttpPut]
        [Route("actualizar/{id}")]
        public ActionResult ActualizarEquipo(int id, [FromBody] comentarios equipoModificar)
        {
           comentarios? comentarioActual = (from e in _blogContext.comentarios where e.comentarioId == id select e).FirstOrDefault();

            if (comentarioActual == null)
            {
                return NotFound();
            }

            comentarioActual.publicacionId = equipoModificar.publicacionId;
            comentarioActual.comentario = equipoModificar.comentario;
            comentarioActual.usuarioId = equipoModificar.usuarioId;
            

            _blogContext.Entry(comentarioActual).State = EntityState.Modified;

            _blogContext.SaveChanges();

            return Ok(comentarioActual);
        }

        [HttpDelete]
        [Route("eliminar/{id}")]
        public ActionResult EliminarEquipo(int id)
        {
            comentarios? comentarios = (from e in _blogContext.comentarios where e.comentarioId == id select e).FirstOrDefault();

            // Verificamos que exista el registro según su ID
            if (comentarios == null)
            {
                return NotFound();
            }

            _blogContext.comentarios.Attach(comentarios);
            _blogContext.comentarios.Remove(comentarios);
            _blogContext.SaveChanges();

            return Ok(comentarios);
        }
    }
}
