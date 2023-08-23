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
    public class VistaClienteConDatoController : ControllerBase
    {
        private readonly LolabumContext _context;

        public VistaClienteConDatoController(LolabumContext context)
        {
            _context = context;
        }

        // GET: api/VistaClienteConDato
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VistaClienteConDato>>> GetVistaClienteConDato()
        {
            if (_context.VistaClienteConDatos == null)
            {
                return NotFound();
            }
            return await _context.VistaClienteConDatos.ToListAsync();
        }
    }
}
