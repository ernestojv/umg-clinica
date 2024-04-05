using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using UMG_Clinica.Models;

namespace UMG_Clinica.Controllers
{
    public class UsuarioController : ApiController
    {
        private readonly ClinicaDbContext _dbContext = new ClinicaDbContext();
        
        public IHttpActionResult Get() {
            var usuarios = _dbContext.Usuario.ToList();
            return Ok(usuarios);
        }
        public IHttpActionResult Post([FromBody] Usuario usuario) {
            _dbContext.Usuario.Add(usuario);
            _dbContext.SaveChanges();
            return Ok();
        }
        public IHttpActionResult Put([FromBody] Usuario usuario) {
            var usuarioDb = _dbContext.Usuario.Find(usuario.NombreDeUsuario);
            if (usuarioDb == null) {
                return NotFound();
            }
            usuarioDb.Nombre = usuario.Nombre;
            usuarioDb.Contrasena = usuario.Contrasena;
            _dbContext.SaveChanges();
            return Ok();
        }
        public IHttpActionResult Delete(string id) {
            var usuarioDb = _dbContext.Usuario.Find(id);
            if (usuarioDb == null) {
                return NotFound();
            }
            _dbContext.Usuario.Remove(usuarioDb);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
