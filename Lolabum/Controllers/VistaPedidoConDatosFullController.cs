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
    public class VistaPedidoConDatosFullController : ControllerBase
    {
        private readonly LolabumContext _context;

        public VistaPedidoConDatosFullController(LolabumContext context)
        {
            _context = context;
        }


        // GET: api/VistaEmpleadoConDatosFull
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VistaPedidoConDatosFull>>> GetVistaPedidoConDatoFull()
        {

            return await _context.VistaPedidoConDatosFulls.ToListAsync();

        }
    }
}
