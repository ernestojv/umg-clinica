using System;
using System.Linq;
using System.Web.Http;
using UMG_Clinica.Models;

namespace UMG_Clinica.Controllers {
    [System.Web.Http.RoutePrefix("api/clinica")]
    public class ConsultaController : ApiController {
        private readonly ClinicaDbContext _dbContext = new ClinicaDbContext();

        [Route("")]
        public IHttpActionResult Get() {
            try {
                var consulta = _dbContext.Consulta.ToList();
                return Ok(consulta);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id) {
            try {
                var consulta = _dbContext.Consulta.Find(id);
                if (consulta == null) {
                    return NotFound();
                }
                return Ok(consulta);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
        }

        [Route("")]
        public IHttpActionResult Post([FromBody] Consulta consulta) {
            try {
                _dbContext.Consulta.Add(consulta);
                _dbContext.SaveChanges();
                return Ok(consulta);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
        }

        [Route("{id}")]
        public IHttpActionResult Put(int id, [FromBody] Consulta consulta) {
            try {
                var consultaDb = _dbContext.Consulta.Find(id);
                if (consultaDb == null) {
                    return NotFound();
                }
                consultaDb.Observaciones = consulta.Observaciones;
                consultaDb.Fecha = consulta.Fecha;
                consultaDb.IdClinica = consulta.IdClinica;
                consultaDb.IdPaciente = consulta.IdPaciente;
                consultaDb.IdEmpleado = consulta.IdEmpleado;
                consultaDb.IdCita = consulta.IdCita;

                _dbContext.SaveChanges();
                return Ok(consultaDb);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id) {
            try {
                var consulta = _dbContext.Consulta.Find(id);
                if (consulta == null) {
                    return NotFound();
                }
                _dbContext.Consulta.Remove(consulta);
                _dbContext.SaveChanges();
                return Ok();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return InternalServerError();
            }
        }

    }
}