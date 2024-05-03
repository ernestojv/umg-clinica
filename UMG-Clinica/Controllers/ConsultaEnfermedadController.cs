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
        public IHttpActionResult Get()
        {
            try
            {
                var consultaE = _dbContext.Consulta_Enfermedad.ToList();
                return Ok(consultaE);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{ID}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var consultaE = _dbContext.Consulta_Enfermedad.Find(id);
                if (consultaE == null)
                {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent("Consulta no encontrada")
                    };
                    return ResponseMessage(responseMessage);
                }
                return Ok(consultaE);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("")]
        public IHttpActionResult Post([FromBody] Consulta_Enfermedad consultaE)
        {
            try
            {
                _dbContext.Consulta_Medicina.Add(consultaE);
                _dbContext.SaveChanges();
                return Ok(consultaE);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("")]
        public IHttpActionResult Put([FromBody] Consulta_Enfermedad consultaE)
        {
            try
            {
                _dbContext.Entry(consultaE).State = System.Data.Entity.EntityState.Modified;
                _dbContext.SaveChanges();
                return Ok(consultaE);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("{ID}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var consultaE = _dbContext.Consulta_Enfermedad.Find(id);
                if (consultaE == null)
                {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent("Consulta no encontrada")
                    };
                    return ResponseMessage(responseMessage);
                }
                _dbContext.Consulta_Enfermedad.Remove(consultaE);
                _dbContext.SaveChanges();
                return Ok(consultaE);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
