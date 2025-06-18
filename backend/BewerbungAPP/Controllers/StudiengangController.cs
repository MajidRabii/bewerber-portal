using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BewerbungAPP.Data;
using BewerbungAPP.Models;

namespace BewerbungAPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudiengangController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudiengangController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Studiengang>>> GetAll()
        {
            return await _context.Studiengaenge.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Studiengang>> GetById(int id)
        {
            var item = await _context.Studiengaenge.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Studiengang>> Create(Studiengang item)
        {
            _context.Studiengaenge.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Studiengang item)
        {
            if (id != item.Id) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;

            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Studiengaenge.Any(e => e.Id == id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Studiengaenge.FindAsync(id);
            if (item == null) return NotFound();
            _context.Studiengaenge.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
