using engenharia_de_software_pb.BLL.Models;
using engenharia_de_software_pb.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace engenharia_de_software_pb.professores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessoresController : ControllerBase
    {
        private readonly IRepository<Professor> _professoresRepository;

        public ProfessoresController(IRepository<Professor> professoresRepository)
        {
            _professoresRepository = professoresRepository;
        }

        // GET: api/Professores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Professor>>> GetProfessores()
        {
            var professores = await _professoresRepository.GetAll();
            return professores.ToList();
        }

        // GET: api/Professores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Professor>> GetProfessor(int id)
        {
            var professor = await _professoresRepository.GetById(id);

            if (professor == null)
            {
                return NotFound();
            }

            return professor;
        }

        // POST: api/Professores
        [HttpPost]
        public async Task<ActionResult<Professor>> PostProfessor(Professor professor)
        {
            professor = await _professoresRepository.Create(professor);
            return CreatedAtAction("GetProfessores", new { id = professor.Id }, professor);
        }

        // PUT: api/Professores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfessor(int id, Professor professor)
        {
            if (id != professor.Id)
            {
                return BadRequest();
            }

            try
            {
                await _professoresRepository.Update(professor);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // DELETE: api/Professores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessor(int id)
        {
            var professor = await _professoresRepository.GetById(id);
            if (professor == null)
            {
                return NotFound();
            }

            await _professoresRepository.Delete(professor);

            return NoContent();
        }

        private bool ProfessorExists(int id)
        {
            return _professoresRepository.GetById(id).Result != null;
        }
    }
}
