using System.Linq.Expressions;
using engenharia_de_software_pb.BLL.Factories;
using engenharia_de_software_pb.BLL.Models;
using engenharia_de_software_pb.Data;
using engenharia_de_software_pb.Data.Interfaces;
using engenharia_de_software_pb.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace engenharia_de_software_pb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotasController : ControllerBase
    {
        private readonly IRepository<Notas> _notasRepository;

        public NotasController(IRepository<Notas> notasRepository)
        {
            _notasRepository = notasRepository;
        }

        // GET: api/Notas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notas>>> GetNotas()
        {
            var notas = await _notasRepository.GetAll();
            return notas.ToList();
        }

        // GET: api/Notas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Notas>> GetNotas(int id)
        {
            var notas = await _notasRepository.GetById(id);

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
            try
            {
                await _notasRepository.Create(notas);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
            

            return CreatedAtAction("GetNotas", new { id = notas.Id }, notas);
        }

        // PUT: api/Notas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotas(int id, Notas notas)
        {
            notas.Aluno = null;
            if (id != notas.Id)
            {
                return BadRequest();
            }

            try
            {
                await _notasRepository.Update(notas);
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

            return Ok();
        }

        // DELETE: api/Notas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotas(int id)
        {
            var notas = await _notasRepository.GetById(id);
            if (notas == null)
            {
                return NotFound();
            }

            try
            {
                await _notasRepository.Delete(notas);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                return BadRequest();
            }



        }

        private bool NotasExists(int id)
        {
            return _notasRepository.GetById(id).Result != null;
        }
    }
}
