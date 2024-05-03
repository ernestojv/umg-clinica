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
        public IHttpActionResult Get()
        {
            try
            {
                var consultasMedicina = _dbContext.Consulta_Medicina.ToList();
                return Ok(consultasMedicina);
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
                var consultaMedicina = _dbContext.Consulta_Medicina.Find(id);
                if (consultaMedicina == null)
                {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent("Consulta de medicina no encontrada")
                    };
                    return ResponseMessage(responseMessage);
                }
                return Ok(consultaMedicina);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("")]
        public IHttpActionResult Post([FromBody] Consulta_Medicina consultaMedicina)
        {
            try
            {
                _dbContext.Consulta_Medicina.Add(consultaMedicina);
                _dbContext.SaveChanges();
                return Ok(consultaMedicina);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("")]
        public IHttpActionResult Put([FromBody] Consulta_Medicina consultaMedicina)
        {
            try
            {
                _dbContext.Entry(consultaMedicina).State = System.Data.Entity.EntityState.Modified;
                _dbContext.SaveChanges();
                return Ok(consultaMedicina);
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
                var consultaMedicina = _dbContext.Consulta_Medicina.Find(id);
                if (consultaMedicina == null)
                {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent("Consulta de medicina no encontrada")
                    };
                    return ResponseMessage(responseMessage);
                }
                _dbContext.Consulta_Medicina.Remove(consultaMedicina);
                _dbContext.SaveChanges();
                return Ok(consultaMedicina);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}