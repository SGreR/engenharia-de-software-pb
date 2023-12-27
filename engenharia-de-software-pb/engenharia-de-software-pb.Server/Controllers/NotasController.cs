using engenharia_de_software_pb.BLL.Models;
using engenharia_de_software_pb.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace engenharia_de_software_pb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NotasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Notas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notas>>> GetNotas()
        {
            var notas = _context.Notas.ToListAsync();
            return await notas;
        }

        // GET: api/Notas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Notas>> GetNotas(int id)
        {
            var notas = await _context.Notas
                .Include(n => n.Reading)
                .Include(n => n.Writing)
                .Include(n => n.Listening)
                .Include(n => n.Grammar)
                .Include(n => n.Speaking)
                .Include(n => n.ClassPerformance)
                .FirstOrDefaultAsync(n => n.Id == id);

            if (notas == null)
            {
                return NotFound();
            }

            return notas;
        }

        // POST: api/Notas
        [HttpPost]
        public async Task<ActionResult<Notas>> PostNotas(Notas notas)
        {
            _context.Notas.Add(notas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotas", new { id = notas.Id }, notas);
        }

        // PUT: api/Notas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotas(int id, Notas notas)
        {
            if (id != notas.Id)
            {
                return BadRequest();
            }

            _context.Entry(notas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotasExists(id))
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

        // DELETE: api/Notas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotas(int id)
        {
            var notas = await _context.Notas.FindAsync(id);
            if (notas == null)
            {
                return NotFound();
            }

            _context.Notas.Remove(notas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NotasExists(int id)
        {
            return _context.Notas.Any(e => e.Id == id);
        }
    }
}
