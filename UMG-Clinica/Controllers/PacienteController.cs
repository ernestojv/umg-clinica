using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using UMG_Clinica.Models;

namespace UMG_Clinica.Controllers {
    [RoutePrefix("api/paciente")]
    public class PacienteController : ApiController {
        private readonly ClinicaDbContext _dbContext = new ClinicaDbContext();

        [Route("")]
        public IHttpActionResult Get() {
            try {
                var pacientes = _dbContext.Paciente.ToList();
                return Ok(pacientes);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [Route("{idPaciente}")]
        public IHttpActionResult Get(int idPaciente) {
            try {
                var paciente = _dbContext.Paciente.Find(idPaciente);
                if (paciente == null) {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound) {
                        Content = new StringContent("Paciente no encontrado")
                    };

                    return ResponseMessage(responseMessage);
                }
                return Ok(paciente);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [Route("")]
        public IHttpActionResult Post([FromBody] Paciente paciente) {
            try {
                _dbContext.Paciente.Add(paciente);
                _dbContext.SaveChanges();
                return Ok(paciente);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [Route("{idPaciente}")]
        public IHttpActionResult Put(int idPaciente, [FromBody] Paciente paciente) {
            try {
                var pacienteDb = _dbContext.Paciente.Find(idPaciente);
                if (pacienteDb == null) {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound) {
                        Content = new StringContent("Paciente no encontrado")
                    };

                    return ResponseMessage(responseMessage);
                }

                pacienteDb.Nombre = paciente.Nombre;
                pacienteDb.Edad = paciente.Edad;
                pacienteDb.Sexo = paciente.Sexo;
                pacienteDb.NumeroDeTelefono = paciente.NumeroDeTelefono;

                _dbContext.SaveChanges();
                return Ok(pacienteDb);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [Route("{idPaciente}")]
        public IHttpActionResult Delete(int idPaciente) {
            try {
                var paciente = _dbContext.Paciente.Find(idPaciente);
                if (paciente == null) {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound) {
                        Content = new StringContent("Paciente no encontrado")
                    };

                    return ResponseMessage(responseMessage);
                }

                _dbContext.Paciente.Remove(paciente);
                _dbContext.SaveChanges();
                return Ok(paciente);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
    }
}