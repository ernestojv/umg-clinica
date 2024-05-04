using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
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
                if (usuario == null) {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound) {
                        Content = new StringContent("Usuario no encontrado")
                    };

                    return ResponseMessage(responseMessage);
                }
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
                if (usuarioDb != null) {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.Conflict) {
                        Content = new StringContent("Usuario ya registrado")
                    };

                    return ResponseMessage(responseMessage);
                }
                _dbContext.Usuario.Add(usuario);
                _dbContext.SaveChanges();
                return Ok(usuario);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }

        }
        [Route("{nombreDeUsuario}")]
        [HttpPut]
        public IHttpActionResult Put([FromBody] Usuario usuario, string nombreDeUsuario) {
            try {
                var usuarioDb = _dbContext.Usuario.Find(nombreDeUsuario);
                if (usuarioDb == null) {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound) {
                        Content = new StringContent("Usuario no encontrado")
                    };

                    return ResponseMessage(responseMessage);
                }
                usuarioDb.Nombre = usuario.Nombre;
                usuarioDb.Contrasena = usuario.Contrasena;
                usuario.NombreDeUsuario = nombreDeUsuario;
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
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound) {
                        Content = new StringContent("Usuario no encontrado")
                    };

                    return ResponseMessage(responseMessage);
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
