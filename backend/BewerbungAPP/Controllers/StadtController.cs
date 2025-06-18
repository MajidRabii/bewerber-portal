using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BewerbungAPP.Data;
using BewerbungAPP.Models;

namespace BewerbungAPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StadtController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StadtController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/stadt
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stadt>>> GetAll()
        {
            // LINQ: select all cities
            return await _context.Staedte.ToListAsync();
        }

        // GET: api/stadt/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stadt>> GetById(int id)
        {
            var stadt = await _context.Staedte.FindAsync(id);
            if (stadt == null)
                return NotFound();

            return stadt;
        }

        // POST: api/stadt
        [HttpPost]
        public async Task<ActionResult<Stadt>> Create(Stadt stadt)
        {
            _context.Staedte.Add(stadt);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = stadt.Id }, stadt);
        }

        // PUT: api/stadt/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Stadt stadt)
        {
            if (id != stadt.Id)
                return BadRequest();

            _context.Entry(stadt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Staedte.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/stadt/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var stadt = await _context.Staedte.FindAsync(id);
            if (stadt == null)
                return NotFound();

            _context.Staedte.Remove(stadt);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
