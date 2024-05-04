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
    [System.Web.Http.RoutePrefix("api/enfermedad")]

    public class EnfermedadController : ApiController
    {
        private readonly ClinicaDbContext _dbContext = new ClinicaDbContext();

        [Route("")]
        public IHttpActionResult Get()
        {
            try
            {
                var Enfermedades = _dbContext.Enfermedad.ToList();
                return Ok(Enfermedades);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{ID_Enfermedad}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var enfermedad = _dbContext.Enfermedad.Find(id);
                if (enfermedad == null)
                {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent("Enfermedad no encontrada")
                    };
                    return ResponseMessage(responseMessage);
                }
                return Ok(enfermedad);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("")]
        public IHttpActionResult Post([FromBody] Enfermedad enfermedad)
        {
            try
            {
                var medicamentoDb = _dbContext.Medicamento.Find(enfermedad.IdEnfermedad);
                if (medicamentoDb != null)
                {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.Conflict)
                    {
                        Content = new StringContent("Enfermedad ya registrada")
                    };
                    return ResponseMessage(responseMessage);
                }
                _dbContext.Enfermedad.Add(enfermedad);
                _dbContext.SaveChanges();
                return Ok(enfermedad);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("")]
        public IHttpActionResult Put([FromBody] Enfermedad enfermedad)
        {
            try
            {
                _dbContext.Entry(enfermedad).State = System.Data.Entity.EntityState.Modified;
                _dbContext.SaveChanges();
                return Ok(enfermedad);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("{ID_Enfermedad}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var enfermedad = _dbContext.Enfermedad.Find(id);
                if (enfermedad == null)
                {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent("Enfermedad no encontrada")
                    };
                    return ResponseMessage(responseMessage);
                }
                _dbContext.Enfermedad.Remove(enfermedad);
                _dbContext.SaveChanges();
                return Ok(enfermedad);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
