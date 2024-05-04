using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using UMG_Clinica.Models;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace UMG_Clinica.Controllers
{
    [System.Web.Http.RoutePrefix("api/consultaenfermedad")]
    public class ConsultaEnfermedadController : ApiController
    {
        private readonly ClinicaDbContext _dbContext = new ClinicaDbContext();

        [Route("")]
        public IHttpActionResult Get() {
            try {
                var consultaEnfermedad = _dbContext.ConsultaEnfermedad.ToList();
                return Ok(consultaEnfermedad);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id) {
            try {
                var consultaEnfermedad = _dbContext.ConsultaEnfermedad.Find(id);
                if (consultaEnfermedad == null) {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound) {
                        Content = new StringContent("ConsultaEnfermedad no encontrada")
                    };
                    return ResponseMessage(responseMessage);
                }
                return Ok(consultaEnfermedad);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [Route("")]
        public IHttpActionResult Post([FromBody] ConsultaEnfermedad consultaEnfermedad) {
            try {
                _dbContext.ConsultaEnfermedad.Add(consultaEnfermedad);
                _dbContext.SaveChanges();
                return Ok(consultaEnfermedad);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [Route("{id}")]
        public IHttpActionResult Put(int id, [FromBody] ConsultaEnfermedad consultaEnfermedad) {
            try {
                var consultaEnfermedadDb = _dbContext.ConsultaEnfermedad.Find(id);
                if (consultaEnfermedadDb == null) {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound) {
                        Content = new StringContent("ConsultaEnfermedad no encontrada")
                    };
                    return ResponseMessage(responseMessage);
                }
                consultaEnfermedadDb.IdConsulta = consultaEnfermedad.IdConsulta;
                consultaEnfermedadDb.IdEnfermedad = consultaEnfermedad.IdEnfermedad;
                _dbContext.SaveChanges();
                return Ok(consultaEnfermedadDb);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id) {
            try {
                var consultaEnfermedad = _dbContext.ConsultaEnfermedad.Find(id);
                if (consultaEnfermedad == null) {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound) {
                        Content = new StringContent("ConsultaEnfermedad no encontrada")
                    };
                    return ResponseMessage(responseMessage);
                }
                _dbContext.ConsultaEnfermedad.Remove(consultaEnfermedad);
                _dbContext.SaveChanges();
                return Ok(consultaEnfermedad);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
    }
}
