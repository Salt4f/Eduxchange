using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduxchangeAPI.Data;
using EduxchangeAPI.Models;

namespace EduxchangeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GivesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public GivesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Gives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Give>>> GetGives([FromQuery(Name = "fulfilled")] bool? fulfilled)
        {
            if (fulfilled != null)
            {
                return await _context.Gives
                    .Where(n => n.Fulfilled == fulfilled)
                    .Include(n => n.Author)
                    .ToListAsync();
            }

            return await _context.Gives
                .Include(n => n.Author)
                .ToListAsync();
        }

        // GET: api/Gives/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Give>> GetGive(long id)
        {
            var give = await _context.Gives.FindAsync(id);

            if (give == null)
            {
                return NotFound();
            }

            return give;
        }

        // PUT: api/Gives/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGive(long id, Give give)
        {
            if (id != give.Id)
            {
                return BadRequest();
            }

            _context.Entry(give).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiveExists(id))
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

        // POST: api/Gives
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Give>> PostGive(Give give)
        {
            _context.Gives.Add(give);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGive", new { id = give.Id }, give);
        }

        // DELETE: api/Gives/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGive(long id)
        {
            var give = await _context.Gives.FindAsync(id);
            if (give == null)
            {
                return NotFound();
            }

            _context.Gives.Remove(give);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GiveExists(long id)
        {
            return _context.Gives.Any(e => e.Id == id);
        }
    }
}
