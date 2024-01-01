using engenharia_de_software_pb.BLL.Factories;
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
    public class NotasController : ControllerBase
    {
        private readonly NotasRepository _notasRepository;

        public NotasController(NotasRepository notasRepository)
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

            var novaNota = NotasFactory.CreateNotas(alunoId: notas.AlunoId);
            novaNota = await _notasRepository.Create(novaNota);

            novaNota.Reading = NotaSimplesFactory<Reading>.CreateNotaSimples(NotasId: novaNota.Id, primeiraNota: notas.Reading.PrimeiraNota, segundaNota: notas.Reading.SegundaNota);
            novaNota.Writing = NotaSimplesFactory<Writing>.CreateNotaSimples(NotasId: novaNota.Id, primeiraNota: notas.Writing.PrimeiraNota, segundaNota: notas.Writing.SegundaNota);
            novaNota.Listening = NotaSimplesFactory<Listening>.CreateNotaSimples(NotasId: novaNota.Id, primeiraNota: notas.Listening.PrimeiraNota, segundaNota: notas.Listening.SegundaNota);
            novaNota.Grammar = NotaSimplesFactory<Grammar>.CreateNotaSimples(NotasId: novaNota.Id, primeiraNota: notas.Grammar.PrimeiraNota, segundaNota: notas.Grammar.SegundaNota);
            novaNota.ClassPerformance = ClassPerformanceFactory.CreateClassPerformance(NotasId: novaNota.Id, presenceGrade: notas.ClassPerformance.PresenceGrade, homeworkGrade: notas.ClassPerformance.HomeworkGrade, participationGrade: notas.ClassPerformance.ParticipationGrade, behaviorGrade: notas.ClassPerformance.BehaviorGrade);
            novaNota.Speaking = SpeakingFactory.CreateSpeaking(NotasId: novaNota.Id, productionAndFluencyGrade: notas.Speaking.ProductionAndFluencyGrade, spokenInteractionGrade: notas.Speaking.SpokenInteractionGrade, languageRangeGrade: notas.Speaking.LanguageRangeGrade, accuracyGrade: notas.Speaking.AccuracyGrade, l2Use: notas.Speaking.L2Use);

            notas = await _notasRepository.Update(novaNota);

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

            await _notasRepository.Delete(notas);

            return Ok();
        }

        private bool NotasExists(int id)
        {
            return _notasRepository.GetById(id).Result != null;
        }
    }
}
