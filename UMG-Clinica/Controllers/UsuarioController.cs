using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using UMG_Clinica.Models;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace UMG_Clinica.Controllers {
    [System.Web.Http.RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController {
        private readonly ClinicaDbContext _dbContext = new ClinicaDbContext();

        [Route("")]
        public IHttpActionResult Get() {
            try {
                var usuarios = _dbContext.Usuario.ToList();
                return Ok(usuarios);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
        [Route("{nombreDeUsuario}")]
        public IHttpActionResult Get(string nombreDeUsuario) {
            try {
                var usuario = _dbContext.Usuario.Find(nombreDeUsuario);
                if (usuario == null) return NotFound();
                return Ok(usuario);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
        [Route("")]
        public IHttpActionResult Post([FromBody] Usuario usuario) {
            try {
                var usuarioDb = _dbContext.Usuario.Find(usuario.NombreDeUsuario);
                if (usuarioDb != null) return Conflict();
                _dbContext.Usuario.Add(usuario);
                _dbContext.SaveChanges();
                return Ok(usuario);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }

        }
        [Route("")]
        public IHttpActionResult Put([FromBody] Usuario usuario) {
            try {
                var usuarioDb = _dbContext.Usuario.Find(usuario.NombreDeUsuario);
                if (usuarioDb == null) {
                    return NotFound();
                }
                usuarioDb.Nombre = usuario.Nombre;
                usuarioDb.Contrasena = usuario.Contrasena;
                _dbContext.SaveChanges();
                return Ok(usuario);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        [Route("{nombreDeUsuario}")]
        public IHttpActionResult Delete(string nombreDeUsuario) {
            try {
                var usuario = _dbContext.Usuario.Find(nombreDeUsuario);
                if (usuario == null) {
                    return NotFound();
                }
                _dbContext.Usuario.Remove(usuario);
                _dbContext.SaveChanges();
                return Ok(usuario);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
    }
}
