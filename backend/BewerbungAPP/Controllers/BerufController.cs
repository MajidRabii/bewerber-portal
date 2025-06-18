using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BewerbungAPP.Data;
using BewerbungAPP.Models;

namespace BewerbungAPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BerufController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BerufController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Beruf>>> GetAll()
        {
            return await _context.Berufe.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Beruf>> GetById(int id)
        {
            var item = await _context.Berufe.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Beruf>> Create(Beruf item)
        {
            _context.Berufe.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Beruf item)
        {
            if (id != item.Id) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;

            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Berufe.Any(e => e.Id == id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Berufe.FindAsync(id);
            if (item == null) return NotFound();
            _context.Berufe.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
