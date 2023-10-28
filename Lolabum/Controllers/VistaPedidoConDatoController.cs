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

        // GET: api/VistaEmpleadoConDato
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VistaPedidoConDato>>> GetVistaPedidoConDato()
        {

            var pedidos = from pedido in await _context.VistaPedidoConDatos.ToListAsync()
                          where pedido.Estado == true
                          select pedido;

            return pedidos.ToList();

        }

        // GET: api/VistaEmpleadoConDato/full
        [HttpGet("full")]
        public async Task<ActionResult<IEnumerable<VistaPedidoConDato>>> GetVistaPedidoConDatoFull()
        {

            return await _context.VistaPedidoConDatos.ToListAsync();

        }
    }
}
