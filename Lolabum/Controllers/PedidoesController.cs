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
    public class PedidoesController : ControllerBase
    {
        private readonly LolabumContext _context;

        public PedidoesController(LolabumContext context)
        {
            _context = context;
        }

        // GET: api/Pedidoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
        {

            var pedidos = from pedido in await _context.Pedidos.ToListAsync()
                             where pedido.Estado == true
                             select pedido;

            return pedidos.ToList();
        }

        // GET: api/Pedidoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
          if (_context.Pedidos == null)
          {
              return NotFound();
          }
            var pedido = await _context.Pedidos.FindAsync(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return pedido;
        }

        // PUT: api/Pedidoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, PedidoEditarModel pedido)
        {

            var nuevoPedido = new Pedido
            {
                pedido = pedido.pedido,
                IdCliente = pedido.IdCliente,
                IdVehiculos = pedido.IdVehiculos,
                IdFactura = pedido.IdFactura,
                IdPedido = pedido.IdPedido,
                Estado = pedido.Estado,
            };


            if (id != nuevoPedido.IdPedido)
            {
                return BadRequest();
            }

            _context.Entry(nuevoPedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();


        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pedido>> PostCliente(PedidoCreacionModel pedido)
        {
            try
            {
                // Crear un nuevo objeto Pedido con los datos necesarios
                var nuevoPedido = new Pedido
                {
                    pedido = pedido.pedido,
                    IdCliente = pedido.IdCliente,
                    IdVehiculos = pedido.IdVehiculos,
                };

                _context.Pedidos.Add(nuevoPedido);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetPedido", new { id = pedido.IdPedido }, pedido);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NoContent();
            }
        }

        // DELETE: api/Pedidoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);

            if (pedido == null)
            {
                return NotFound();
            }

            // Marcar el concesionario como inactivo
            pedido.Estado = false;
            _context.Entry(pedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool PedidoExists(int id)
        {
            return (_context.Pedidos?.Any(e => e.IdPedido == id)).GetValueOrDefault();
        }
    }
}
