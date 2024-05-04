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
    [System.Web.Http.RoutePrefix("api/consultamedicina")]
    public class ConsultaMedicinaController : ApiController
    {
        private readonly ClinicaDbContext _dbContext = new ClinicaDbContext();

        [Route("")]
        public IHttpActionResult Get() {
            try {
                var consultaMedicina = _dbContext.ConsultaMedicina.ToList();
                return Ok(consultaMedicina);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id) {
            try {
                var consultaMedicina = _dbContext.ConsultaMedicina.Find(id);
                if (consultaMedicina == null) {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound) {
                        Content = new StringContent("ConsultaMedicina no encontrada")
                    };
                    return ResponseMessage(responseMessage);
                }
                return Ok(consultaMedicina);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [Route("")]
        public IHttpActionResult Post([FromBody] ConsultaMedicina consultaMedicina) {
            try {
                _dbContext.ConsultaMedicina.Add(consultaMedicina);
                _dbContext.SaveChanges();
                return Ok(consultaMedicina);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [Route("{id}")]
        public IHttpActionResult Put(int id, [FromBody] ConsultaMedicina consultaMedicina) {
            try {
                var consultaMedicinaDb = _dbContext.ConsultaMedicina.Find(id);
                if (consultaMedicinaDb == null) {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound) {
                        Content = new StringContent("ConsultaMedicina no encontrada")
                    };
                    return ResponseMessage(responseMessage);
                }
                consultaMedicinaDb.IdConsulta = consultaMedicina.IdConsulta;
                consultaMedicinaDb.IdMedicamento = consultaMedicina.IdMedicamento;
                consultaMedicinaDb.Indicaciones = consultaMedicina.Indicaciones;

                return Ok(consultaMedicinaDb);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id) {
            try {
                var consultaMedicina = _dbContext.ConsultaMedicina.Find(id);
                if (consultaMedicina == null) {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound) {
                        Content = new StringContent("ConsultaMedicina no encontrada")
                    };
                    return ResponseMessage(responseMessage);
                }
                _dbContext.ConsultaMedicina.Remove(consultaMedicina);
                _dbContext.SaveChanges();
                return Ok();
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
    }
}