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
    public class HelpsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public HelpsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Helps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Helps>>> GetHelps()
        {

            return await _context.Helps
                .Include(n => n.Need)
                .Include(n => n.Individual)
                .ToListAsync();
        }

        // GET: api/Helps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Helps>> GetHelp(string individualid, long needid)
        {
            var help = await _context.Helps
                .Include(g => g.Need)
                .Include(g => g.Individual)
                .FirstOrDefaultAsync(g => g.IndividualID == individualid && g.NeedID == needid);

            if (help == null)
            {
                return NotFound();
            }

            return help;
        }

        // PUT: api/Helps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHelp(string individualid, long needid, Helps help)
        {
            if (needid != help.NeedID || help.IndividualID != individualid)
            {
                return BadRequest();
            }

            _context.Entry(help).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HelpsExists(individualid, needid))
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

        // POST: api/Helps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Helps>> PostHelps(Helps help)
        {
            _context.Helps.Add(help);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHelps", new { needid = help.NeedID, individualid = help.IndividualID }, help);
        }

        // DELETE: api/Helps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHelps(string individualid, long needid)
        {
            var help = await _context.Helps.FindAsync(individualid, needid);
            if (help == null)
            {
                return NotFound();
            }

            _context.Helps.Remove(help);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HelpsExists(string individualid, long needid)
        {
            return _context.Helps.Any(e => e.IndividualID == individualid & e.NeedID == needid);
        }
    }
}
