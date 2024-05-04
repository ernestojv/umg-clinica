using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using UMG_Clinica.Models;

namespace UMG_Clinica.Controllers {
    [RoutePrefix("api/cita")]
    public class CitaController : ApiController {
        private readonly ClinicaDbContext _dbContext = new ClinicaDbContext();

        [Route("")]
        public IHttpActionResult Get() {
            try {
                var citas = _dbContext.Cita.ToList();
                return Ok(citas);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [Route("{idCita}")]
        public IHttpActionResult Get(int idCita) {
            try {
                var cita = _dbContext.Cita.Find(idCita);
                if (cita == null) {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound) {
                        Content = new StringContent("Cita no encontrada")
                    };

                    return ResponseMessage(responseMessage);
                }
                return Ok(cita);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [Route("")]
        public IHttpActionResult Post([FromBody] Cita cita) {
            try {
                _dbContext.Cita.Add(cita);
                _dbContext.SaveChanges();
                return Ok(cita);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [Route("{idCita}")]
        public IHttpActionResult Put(int idCita, [FromBody] Cita cita) {
            try {
                var citaDb = _dbContext.Cita.Find(idCita);
                if (citaDb == null) {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound) {
                        Content = new StringContent("Cita no encontrada")
                    };

                    return ResponseMessage(responseMessage);
                }
                citaDb.FechaHora = cita.FechaHora;
                citaDb.Estado = cita.Estado;
                citaDb.IdClinica = cita.IdClinica;
                citaDb.IdPaciente = cita.IdPaciente;
                citaDb.IdEmpleado = cita.IdEmpleado;
                _dbContext.SaveChanges();
                return Ok(citaDb);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [Route("{idCita}")]
        public IHttpActionResult Delete(int idCita) {
            try {
                var cita = _dbContext.Cita.Find(idCita);
                if (cita == null) {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound) {
                        Content = new StringContent("Cita no encontrada")
                    };

                    return ResponseMessage(responseMessage);
                }
                _dbContext.Cita.Remove(cita);
                _dbContext.SaveChanges();
                return Ok();
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
    }
}
