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
    [System.Web.Http.RoutePrefix("api/medicamento")]

    public class MedicamentoController : ApiController
    {
        private readonly ClinicaDbContext _dbContext = new ClinicaDbContext();

        [Route("")]
        public IHttpActionResult Get()
        {
            try
            {
                var medicamentos = _dbContext.Medicamento.ToList();
                return Ok(medicamentos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{ID_Medicamento}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var medicamento = _dbContext.Medicamento.Find(id);
                if (medicamento == null)
                {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent("Medicamento no encontrado")
                    };
                    return ResponseMessage(responseMessage);
                }
                return Ok(medicamento);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("")]
        public IHttpActionResult Post([FromBody] Medicamento medicamento)
        {
            try
            {
                var medicamentoDb = _dbContext.Medicamento.Find(medicamento.ID_Medicamento);
                if (medicamentoDb != null)
                {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.Conflict)
                    {
                        Content = new StringContent("Medicamento ya registrado")
                    };
                    return ResponseMessage(responseMessage);
                }
                _dbContext.Medicamento.Add(medicamento);
                _dbContext.SaveChanges();
                return Ok(medicamento);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("")]
        public IHttpActionResult Put([FromBody] Medicamento medicamento)
        {
            try
            {
                _dbContext.Entry(medicamento).State = System.Data.Entity.EntityState.Modified;
                _dbContext.SaveChanges();
                return Ok(medicamento);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("{ID_Medicamento}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var medicamento = _dbContext.Medicamento.Find(id);
                if (medicamento == null)
                {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent("Medicamento no encontrado")
                    };
                    return ResponseMessage(responseMessage);
                }
                _dbContext.Medicamento.Remove(medicamento);
                _dbContext.SaveChanges();
                return Ok(medicamento);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}