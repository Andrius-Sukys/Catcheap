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
    public class JourneysController : ControllerBase
    {
        private readonly CatcheapAPIContext _context;

        public JourneysController(CatcheapAPIContext context)
        {
            _context = context;
        }

        // GET: api/Journeys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Journeys>>> GetAll()
        {
            return await _context.Journeys.ToListAsync();
        }

        // GET: api/Journeys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Journeys>> GetById(int id)
        {
            var journeys = await _context.Journeys.FindAsync(id);

            if (journeys == null)
            {
                return NotFound();
            }

            return journeys;
        }

        // PUT: api/Journeys/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Journeys journeys)
        {
            if (id != journeys.JourneysId)
            {
                return BadRequest();
            }

            _context.Entry(journeys).State = EntityState.Modified;

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

        // POST: api/Journeys
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Journeys>> Post(Journeys journeys)
        {

            _context.Journeys.Add(journeys);
            await _context.SaveChangesAsync();


            return CreatedAtAction("GetJourneys", new { id = journeys.JourneysId }, journeys);
        }

        // DELETE: api/Journeys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var journeys = await _context.Journeys.FindAsync(id);
            if (journeys == null)
            {
                return NotFound();
            }


            _context.Journeys.Remove(journeys);
            await _context.SaveChangesAsync();


            return NoContent();
        }

        private bool Exists(int id)
        {
            return _context.Journeys.Any(e => e.JourneysId == id);
        }
    }
}
