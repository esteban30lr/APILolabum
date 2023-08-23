using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lolabum.Models;

namespace Lolabum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VistaEmpleadoConDatoController : ControllerBase
    {
        private readonly LolabumContext _context;

        public VistaEmpleadoConDatoController(LolabumContext context)
        {
            _context = context;
        }

        // GET: api/VistaEmpleadoConDato
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VistaEmpleadoConDato>>> GetVistaEmpleadoConDato()
        {
            if (_context.VistaEmpleadoConDatos == null)
            {
                return NotFound();
            }
            return await _context.VistaEmpleadoConDatos.ToListAsync();
        }
    }
}
