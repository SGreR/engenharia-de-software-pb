using engenharia_de_software_pb.BLL.Models;
using engenharia_de_software_pb.Data;
using engenharia_de_software_pb.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace engenharia_de_software_pb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    { 
        private readonly AlunoRepository _alunosRepository;

        public AlunosController(AlunoRepository alunosRepository)
        {
            _alunosRepository = alunosRepository;
        }

        // GET: api/Alunos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos()
        {
            var alunos = await _alunosRepository.GetAll();
            return alunos.ToList();
        }

        // GET: api/Alunos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            var aluno = await _alunosRepository.GetById(id);

            if (aluno == null)
            {
                return NotFound();
            }

            return aluno;
        }

        // POST: api/Alunos
        [HttpPost]
        public async Task<ActionResult<Aluno>> PostAluno(Aluno aluno)
        {
            aluno = await _alunosRepository.Create(aluno);
            return CreatedAtAction("GetAlunos", new { id = aluno.Id }, aluno);
        }

        // PUT: api/Alunos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlunos(int id, Aluno aluno)
        {
            if (id != aluno.Id)
            {
                return BadRequest();
            }

            try
            {
                await _alunosRepository.Update(aluno);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoExists(id))
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

        // DELETE: api/Alunos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            var aluno = await _alunosRepository.GetById(id);
            if (aluno == null)
            {
                return NotFound();
            }

            await _alunosRepository.Delete(aluno);

            return NoContent();
        }

        private bool AlunoExists(int id)
        {
            return _alunosRepository.GetById(id).Result != null;
        }
    }
}
