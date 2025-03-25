using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropiedadsController : ControllerBase
    {
        private readonly MantenimientoDbContext _context;

        public PropiedadsController(MantenimientoDbContext context)
        {
            _context = context;
        }

        // GET: api/Propiedads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Propiedad>>> GetPropiedads()
        {
            return await _context.Propiedads.ToListAsync();
        }

        // GET: api/Propiedads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Propiedad>> GetPropiedad(int id)
        {
            var propiedad = await _context.Propiedads.FindAsync(id);

            if (propiedad == null)
            {
                return NotFound();
            }

            return propiedad;
        }

        // PUT: api/Propiedads/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPropiedad(int id, Propiedad propiedad)
        {
            if (id != propiedad.Id)
            {
                return BadRequest();
            }

            _context.Entry(propiedad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropiedadExists(id))
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

        // POST: api/Propiedads
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Propiedad>> PostPropiedad(Propiedad propiedad)
        {
            _context.Propiedads.Add(propiedad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPropiedad", new { id = propiedad.Id }, propiedad);
        }

        // DELETE: api/Propiedads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePropiedad(int id)
        {
            var propiedad = await _context.Propiedads.FindAsync(id);
            if (propiedad == null)
            {
                return NotFound();
            }

            _context.Propiedads.Remove(propiedad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PropiedadExists(int id)
        {
            return _context.Propiedads.Any(e => e.Id == id);
        }
    }
}
