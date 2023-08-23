
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
    public class VistaPedidoConDatoController : ControllerBase
    {
        private readonly LolabumContext _context;
        public VistaPedidoConDatoController(LolabumContext context)
        {
            _context = context;
        }

        // GET: api/VistaPedidoConDato
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VistaPedidoConDato>>> GetVistaPedidoConDato()
        {
            if (_context.Vehiculos == null)
            {
                return NotFound();
            }
            return await _context.VistaPedidoConDatos.ToListAsync();
        }
    }
}