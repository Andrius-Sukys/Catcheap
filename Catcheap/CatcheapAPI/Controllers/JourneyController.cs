using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatcheapAPI.Data;
using CatcheapAPI.Models.Journeys_Classes;

namespace CatcheapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JourneyController : ControllerBase
    {
        private readonly CatcheapAPIContext _context;

        public JourneyController(CatcheapAPIContext context)
        {
            _context = context;
        }

        // GET: api/Journey
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Journey>>> GetAll()
        {
            return await _context.Journey.ToListAsync();
        }

        // GET: api/Journey/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Journey>> GetById(int id)
        {
            var journey = await _context.Journey.FindAsync(id);

            if (journey == null)
            {
                return NotFound();
            }

            return journey;
        }

        // PUT: api/Journey/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Journey journey)
        {
            if (id != journey.JourneyId)
            {
                return BadRequest();
            }

            _context.Entry(journey).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(id))
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

        // POST: api/Journey
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Journey>> Post(Journey journey)
        {

            _context.Journey.Add(journey);
            await _context.SaveChangesAsync();


            return CreatedAtAction("GetJourney", new { id = journey.JourneyId }, journey);
        }

        // DELETE: api/Journey/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var journey = await _context.Journey.FindAsync(id);
            if (journey == null)
            {
                return NotFound();
            }

            _context.Journey.Remove(journey);
            await _context.SaveChangesAsync();


            return NoContent();
        }

        private bool Exists(int id)
        {
            return _context.Journey.Any(e => e.JourneyId == id);
        }
    }
}
