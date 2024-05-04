using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using UMG_Clinica.Models;

namespace UMG_Clinica.Controllers {
    [System.Web.Http.RoutePrefix("api/empleado")]
    public class EmpleadoController : ApiController {
        private readonly ClinicaDbContext _dbContext = new ClinicaDbContext();

        [Route("")]
        public IHttpActionResult Get() {
            try {
                var empleados = _dbContext.Empleado.ToList();
                return Ok(empleados);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [Route("{idEmpleado}")]
        public IHttpActionResult Get(int idEmpleado) {
            try {
                var empleado = _dbContext.Empleado.Find(idEmpleado);
                if (empleado == null) {
                    var responseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound) {
                        Content = new StringContent("Empleado no encontrado")
                    };

                    return ResponseMessage(responseMessage);
                }
                return Ok(empleado);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [Route("")]
        public IHttpActionResult Post([FromBody] Empleado empleado) {
            try {
                _dbContext.Empleado.Add(empleado);
                _dbContext.SaveChanges();
                return Ok(empleado);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [Route("{idEmpleado}")]
        public IHttpActionResult Put(int idEmpleado, [FromBody] Empleado empleado) {
            try {
                var empleadoDb = _dbContext.Empleado.Find(idEmpleado);
                if (empleadoDb == null) {
                    var responseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound) {
                        Content = new StringContent("Empleado no encontrado")
                    };

                    return ResponseMessage(responseMessage);
                }

                empleadoDb.Nombre = empleado.Nombre;
                empleadoDb.Puesto = empleado.Puesto;
                empleadoDb.NumeroDeTelefono = empleado.NumeroDeTelefono;
                empleadoDb.Dpi = empleado.Dpi;
                empleadoDb.NombreDeUsuario = empleado.NombreDeUsuario;

                _dbContext.SaveChanges();
                return Ok(empleadoDb);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [Route("{idEmpleado}")]
        [HttpDelete]
        public IHttpActionResult Delete(int idEmpleado) {
            try {
                var empleado = _dbContext.Empleado.Find(idEmpleado);
                if (empleado == null) {
                    var responseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound) {
                        Content = new StringContent("Empleado no encontrado")
                    };

                    return ResponseMessage(responseMessage);
                }

                _dbContext.Empleado.Remove(empleado);
                _dbContext.SaveChanges();
                return Ok(empleado);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
    }
}