using engenharia_de_software_pb.BLL.Models;
using engenharia_de_software_pb.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace engenharia_de_software_pb.turmas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmasController : Controller
    {
        private readonly IRepository<Turma> _turmasRepository;

        public TurmasController(IRepository<Turma> turmasRepository)
        {
            _turmasRepository = turmasRepository;
        }

        // GET: api/Turmas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Turma>>> GetTurmas()
        {
            var turmas = await _turmasRepository.GetAll();
            return turmas.ToList();
        }

        // GET: api/Turmas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Turma>> GetTurma(int id)
        {
            var turma = await _turmasRepository.GetById(id);

            if (turma == null)
            {
                return NotFound();
            }

            return turma;
        }

        [HttpGet("GetByRelatedId/{type}/{id}")]
        public async Task<ActionResult<IEnumerable<Turma>>> GetByRelatedId(string type, int id)
        {
            var turmas = await _turmasRepository.GetByRelatedId(type, id);
            return turmas.ToList();
        }

        // POST: api/Turmas
        [HttpPost]
        public async Task<ActionResult<Turma>> PostTurmas(Turma turma)
        {
            try
            {
                await _turmasRepository.Create(turma);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }


            return CreatedAtAction("GetTurma", new { id = turma.Id }, turma);
        }

        // PUT: api/Turmas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTurmas(int id, Turma turma)
        {
            if (id != turma.Id)
            {
                return BadRequest();
            }

            try
            {
                var turmaAntiga = await _turmasRepository.GetById(id);
                turmaAntiga.Nome = turma.Nome;
                AtualizarAlunos(turmaAntiga, turma);
                
                await _turmasRepository.Update(turmaAntiga);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurmaExists(id))
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

        // DELETE: api/Turmas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTurma(int id)
        {
            var turma = await _turmasRepository.GetById(id);
            if (turma == null)
            {
                return NotFound();
            }

            try
            {
                await _turmasRepository.Delete(turma);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                return BadRequest();
            }
        }

        private bool TurmaExists(int id)
        {
            return _turmasRepository.GetById(id).Result != null;
        }

        private void AtualizarAlunos(Turma turmaAntiga, Turma turmaAtualizada)
        {
            foreach (var aluno in turmaAntiga.Alunos.ToList())
            {
                if (!turmaAtualizada.Alunos.Any(a => a.Id == aluno.Id))
                {
                    turmaAntiga.Alunos.Remove(aluno);
                }
            }

            foreach(var aluno in turmaAtualizada.Alunos)
            {
                if (!turmaAntiga.Alunos.Any(a => a.Id == aluno.Id))
                {
                    turmaAntiga.Alunos.Add(aluno);
                }
            }
        }
    }
}
