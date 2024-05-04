using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UMG_Clinica.Models;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace UMG_Clinica.Controllers
{
    [System.Web.Http.RoutePrefix("api/clinica")]
    public class ClinicaController : ApiController
    {
        private readonly ClinicaDbContext _dbContext = new ClinicaDbContext();

        [Route("")]
        public IHttpActionResult Get() {
            try {
                var clinica = _dbContext.Clinica.ToList();
                return Ok(clinica);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id) {
            try {
                var clinica = _dbContext.Clinica.Find(id);
                if (clinica == null) {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound) {
                        Content = new StringContent("Clinica no encontrada")
                    };
                    return ResponseMessage(responseMessage);
                }
                return Ok(clinica);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [Route("")]
        public IHttpActionResult Post([FromBody] Clinica clinica) {
            try {
                _dbContext.Clinica.Add(clinica);
                _dbContext.SaveChanges();
                return Ok(clinica);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [Route("{id}")]
        public IHttpActionResult Put(int id, [FromBody] Clinica clinica) {
            try {
                var clinicaDb = _dbContext.Clinica.Find(id);
                if (clinicaDb == null) {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound) {
                        Content = new StringContent("Clinica no encontrada")
                    };
                    return ResponseMessage(responseMessage);
                }
                clinicaDb.Nombre = clinica.Nombre;
                clinicaDb.Direccion = clinica.Direccion;
                clinicaDb.Telefono = clinica.Telefono;
                _dbContext.SaveChanges();
                return Ok(clinicaDb);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id) {
            try {
                var clinica = _dbContext.Clinica.Find(id);
                if (clinica == null) {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound) {
                        Content = new StringContent("Clinica no encontrada")
                    };
                    return ResponseMessage(responseMessage);
                }
                _dbContext.Clinica.Remove(clinica);
                _dbContext.SaveChanges();
                return Ok(clinica);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
    }
}

        
        

