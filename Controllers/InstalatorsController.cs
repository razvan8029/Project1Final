using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project1.Data;
using Project1.Models;

namespace Project1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstalatorsController : ControllerBase
    {
        private readonly Project1Context _context;

        public InstalatorsController(Project1Context context)
        {
            _context = context;
        }

        // GET: api/Instalators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instalator>>> GetInstalator()
        {
            return await _context.Instalator.ToListAsync();
        }

        // GET: api/Instalators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Instalator>> GetInstalator(Guid id)
        {
            var instalator = await _context.Instalator.FindAsync(id);

            if (instalator == null)
            {
                return NotFound();
            }

            return instalator;
        }

        // PUT: api/Instalators/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstalator(Guid id, Instalator instalator)
        {
            if (id != instalator.ID)
            {
                return BadRequest();
            }

            _context.Entry(instalator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstalatorExists(id))
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

        // POST: api/Instalators
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Instalator>> PostInstalator(Instalator instalator)
        {
            _context.Instalator.Add(instalator);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstalator", new { id = instalator.ID }, instalator);
        }

        // DELETE: api/Instalators/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstalator(Guid id)
        {
            var instalator = await _context.Instalator.FindAsync(id);
            if (instalator == null)
            {
                return NotFound();
            }

            _context.Instalator.Remove(instalator);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InstalatorExists(Guid id)
        {
            return _context.Instalator.Any(e => e.ID == id);
        }
    }
}
