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
    public class IndividualsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public IndividualsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Individuals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Individual>>> GetIndividuals()
        {
            return await _context.Individuals.ToListAsync();
        }

        // GET: api/Individuals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Individual>> GetIndividual(string id)
        {
            var individual = await _context.Individuals
                .Include(i => i.Gives)
                .Include(i => i.Helps)
                .FirstOrDefaultAsync(i => i.Email == id);

            if (individual == null)
            {
                return NotFound();
            }

            return individual;
        }

        // PUT: api/Individuals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIndividual(string id, Individual individual)
        {
            if (id != individual.Email)
            {
                return BadRequest();
            }

            individual.Type = "individual";

            _context.Entry(individual).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IndividualExists(id))
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

        // POST: api/Individuals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Individual>> PostIndividual(Individual individual)
        {
            individual.Type = "individual";
            _context.Individuals.Add(individual);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IndividualExists(individual.Email))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetIndividual", new { id = individual.Email }, individual);
        }

        // DELETE: api/Individuals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIndividual(string id)
        {
            var individual = await _context.Individuals.FindAsync(id);
            if (individual == null)
            {
                return NotFound();
            }

            _context.Individuals.Remove(individual);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IndividualExists(string id)
        {
            return _context.Individuals.Any(e => e.Email == id);
        }
    }
}
