using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using UMG_Clinica.Models;

namespace UMG_Clinica.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ClinicaDbContext _dbContext = new ClinicaDbContext();
        
    }
}
