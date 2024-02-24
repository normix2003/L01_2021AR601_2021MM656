using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using L01_2021AR601_2021MM656.models;
using Microsoft.EntityFrameworkCore;

namespace L01_2021AR601_2021MM656.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class usuariosController : ControllerBase
    {
        private readonly blogContext _blogContext;
        public usuariosController(blogContext blogContext)
        {
            _blogContext = blogContext;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<usuarios> ListadoUsuarios = (from e in _blogContext.usuarios
                                                          select e).ToList();
            if (ListadoUsuarios.Count == 0)
            { return NotFound(); }

            return Ok(ListadoUsuarios);

        }





        //crear

        [HttpPost]
        [Route("add")]
        public IActionResult GuardarEquipo([FromBody] usuarios usuarios)
        {
            try

            {

                _blogContext.usuarios.Add(usuarios);
                _blogContext.SaveChanges();

                return Ok(usuarios);

            }

            catch (Exception ex)

            {
                return BadRequest(ex.Message);
            }


        }


        //modificar

        [HttpPut]
        [Route("actualizar/{id}")]
        public ActionResult ActualizarEquipo(int id, [FromBody] usuarios usuariosModificar)
        {
            usuarios? usuarioActual = (from e in _blogContext.usuarios where e.usuarioId == id select e).FirstOrDefault();

            if (usuarioActual == null)
            {
                return NotFound();
            }

            usuarioActual.rolId = usuariosModificar.rolId;
            usuarioActual.nombreUsuario = usuariosModificar.nombreUsuario;
            usuarioActual.clave = usuariosModificar.clave;
            usuarioActual.nombre = usuariosModificar.nombre;
            usuarioActual.apellido = usuariosModificar.apellido;


            _blogContext.Entry(usuarioActual).State = EntityState.Modified;

            _blogContext.SaveChanges();

            return Ok(usuarioActual);
        }

        [HttpDelete]
        [Route("eliminar/{id}")]
        public IActionResult EliminarEquipo(int id)
        {
            usuarios? usuarios= (from e in _blogContext.usuarios where e.usuarioId== id select e).FirstOrDefault();

            // Verificamos que exista el registro según su ID
            if (usuarios == null)
            {
                return NotFound();
            }

            _blogContext.usuarios.Attach(usuarios);
            _blogContext.usuarios.Remove(usuarios);
            _blogContext.SaveChanges();

            return Ok(usuarios);
        }
    }
}
