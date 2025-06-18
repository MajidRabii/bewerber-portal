using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BewerbungAPP.Data;
using BewerbungAPP.Models;

namespace BewerbungAPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AbschlussartController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AbschlussartController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Abschlussart>>> GetAll()
        {
            return await _context.Abschlussarten.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Abschlussart>> GetById(int id)
        {
            var item = await _context.Abschlussarten.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Abschlussart>> Create(Abschlussart item)
        {
            _context.Abschlussarten.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Abschlussart item)
        {
            if (id != item.Id) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;

            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Abschlussarten.Any(e => e.Id == id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Abschlussarten.FindAsync(id);
            if (item == null) return NotFound();
            _context.Abschlussarten.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
