﻿using System;
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
    public class ConcescionariosController : ControllerBase
    {
        private readonly LolabumContext _context;

        public ConcescionariosController(LolabumContext context)
        {
            _context = context;
        }

        // GET: api/Concescionarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Concescionario>>> GetConcescionarios()
        {
            var concescionarios = from concescionario in await _context.Concescionarios.ToListAsync()
                             where concescionario.Estado == true
                             select concescionario;

            return concescionarios.ToList();
        }

        // GET: api/Concescionarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Concescionario>> GetConcescionario(int id)
        {
          if (_context.Concescionarios == null)
          {
              return NotFound();
          }
            var concescionario = await _context.Concescionarios.FindAsync(id);

            if (concescionario == null)
            {
                return NotFound();
            }

            return concescionario;
        }

        // PUT: api/Concescionarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConcescionario(int id, Concescionario concescionario)
        {
            if (id != concescionario.IdConcesionario)
            {
                return BadRequest();
            }

            _context.Entry(concescionario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConcescionarioExists(id))
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

        // POST: api/Concescionarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Concescionario>> PostConcescionario(Concescionario concescionario)
        {
          if (_context.Concescionarios == null)
          {
              return Problem("Entity set 'LolabumContext.Concescionarios'  is null.");
          }
            _context.Concescionarios.Add(concescionario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConcescionario", new { id = concescionario.IdConcesionario }, concescionario);
        }

        // DELETE: api/Concescionarios/delete/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteConcescionario(int id)
        {
            var concesionario = await _context.Concescionarios.FindAsync(id);

            if (concesionario == null)
            {
                return NotFound();
            }

            // Marcar el concesionario como inactivo
            concesionario.Estado = false;
            _context.Entry(concesionario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConcescionarioExists(id))
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
 

        private bool ConcescionarioExists(int id)
        {
            return (_context.Concescionarios?.Any(e => e.IdConcesionario == id)).GetValueOrDefault();
        }
    }
}
