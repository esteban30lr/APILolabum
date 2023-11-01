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
    public class EmpleadoesController : ControllerBase
    {
        private readonly LolabumContext _context;

        public EmpleadoesController(LolabumContext context)
        {
            _context = context;
        }

        // GET: api/Empleadoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetEmpleados()
        {
            var empleados = await (from empleado in _context.Empleados
                                   join persona in _context.Personas on empleado.IdPersona equals persona.IdPersona
                                   where empleado.Estado == true
                                   select new
                                   {
                                       empleado.Usuario,
                                       empleado.IdEmpleado,
                                       persona.Identificacion,
                                       persona.Nombre1,
                                       persona.Nombre2,
                                       persona.Apellido1,
                                       persona.Apellido2,
                                       persona.Correo,
                                       persona.Telefono,
                                       persona.Edad
                                   }).ToListAsync();

            return empleados;
        }

        // GET: api/Empleadoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetEmpleado(int id)
        {
          if (_context.Empleados == null)
          {
              return NotFound();
          }
            var empleado = await _context.Empleados.FindAsync(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return empleado;
        }

        // PUT: api/Empleadoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(int id, EmpleadoCreacionModel empleado)
        {
            if (id != empleado.IdEmpleado)
            {
                return BadRequest();
            }

            try
            {
                // Crear un nuevo objeto Cliente con los datos necesarios
                var nuevoEmpleado = new Empleado
                {
                    IdPersona = empleado.IdPersona,
                    Usuario = empleado.Usuario,
                    Contrasena = empleado.Contrasena,
                    IdEmpleado = empleado.IdEmpleado,
                    Estado = true
                };
                _context.Entry(nuevoEmpleado).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(id))
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
        public async Task<ActionResult<Empleado>> PostEmpleado(EmpleadoCreacionModel empleado)
        {
            try
            {
                // Crear un nuevo objeto Cliente con los datos necesarios
                var nuevoEmpleado = new Empleado
                {
                    IdPersona = empleado.IdPersona,
                    Usuario = empleado.Usuario,
                    Contrasena = empleado.Contrasena
                };

                _context.Empleados.Add(nuevoEmpleado);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetEmpleado", new { id = empleado.IdEmpleado }, empleado);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NoContent();
            }
        }

        // DELETE: api/Empleadoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            if (_context.Empleados == null)
            {
                return NotFound();
            }
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            // Marcar el empleado como inactivo
            empleado.Estado = false;
            _context.Entry(empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(id))
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


        private bool EmpleadoExists(int id)
        {
            return (_context.Empleados?.Any(e => e.IdEmpleado == id)).GetValueOrDefault();
        }
    }
}
