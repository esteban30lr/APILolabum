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
    public class ClientesController : ControllerBase
    {
        private readonly LolabumContext _context;

        public ClientesController(LolabumContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetClientes()
        {
            var clientes = from cliente in await _context.Clientes.ToListAsync()
                           join persona in await _context.Personas.ToListAsync() on cliente.IdPersona equals persona.IdPersona
                           where cliente.Estado == true
                           select new
                           {
                               cliente.Usuario,
                               cliente.IdCliente,
                               persona.Identificacion,
                               persona.Nombre1,
                               persona.Nombre2,
                               persona.Apellido1,
                               persona.Apellido2,
                               persona.Correo,
                               persona.Telefono,
                               persona.Edad
                           };

            if (clientes.ToList().Count == 0)
            {
                return NotFound();
            }

            return clientes.ToList();
        }



        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, ClienteCreacionModel cliente)
        {
            if (id != cliente.IdCliente)
            {
                return BadRequest();
            }
            
            try
            {
                // Crear un nuevo objeto Cliente con los datos necesarios
                var nuevoCliente = new Cliente
                {
                    IdPersona = cliente.IdPersona,
                    IdCliente = cliente.IdCliente,
                    Usuario = cliente.Usuario,
                    Contrasena = cliente.Contrasena,
                    Estado = true,
                };

                _context.Entry(nuevoCliente).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCliente", new { id = cliente.IdCliente }, cliente);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NoContent();
            }

        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(ClienteCreacionModel cliente)
        {
            try
            {
                // Crear un nuevo objeto Cliente con los datos necesarios
                var nuevoCliente = new Cliente
                {
                    IdPersona = cliente.IdPersona,
                    Usuario = cliente.Usuario,
                    Contrasena = cliente.Contrasena
                };

                _context.Clientes.Add(nuevoCliente);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCliente", new { id = cliente.IdCliente }, cliente);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NoContent();
            }
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            // Marcar el cliente como inactivo
            cliente.Estado = false;
            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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

        private bool ClienteExists(int id)
        {
            return (_context.Clientes?.Any(e => e.IdCliente == id)).GetValueOrDefault();
        }
    }
}
