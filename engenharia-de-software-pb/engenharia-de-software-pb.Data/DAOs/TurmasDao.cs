using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using engenharia_de_software_pb.BLL.Models;
using engenharia_de_software_pb.Data.Interfaces;
using engenharia_de_software_pb.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace engenharia_de_software_pb.Data.DAOs
{
    public class TurmasDao : IDao<Turma>
    {
        private readonly ApplicationDbContext _context;
        private readonly AlunosService _alunosService;

        public TurmasDao(ApplicationDbContext applicationDbContext, AlunosService alunosService)
        {
            _context = applicationDbContext;
            _alunosService = alunosService;
        }

        public async Task<Turma> Add(Turma entity)
        {
            try
            {
                _context.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return entity;
            }
        }

        public async Task<bool> Delete(Turma entity)
        {
            try
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<IEnumerable<Turma>> GetAll()
        {
            return await _context.Turmas
                .ToListAsync();
        }

        public async Task<Turma?> GetById(int id)
        {
            return await _context.Turmas
                .Include(t => t.Alunos)
                .FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<IEnumerable<Turma?>> GetByRelatedId(string type, int id)
        {
            IQueryable<Turma> query = _context.Turmas;

            switch (type)
            {
                case "aluno":
                    query = query.Include(t => t.Alunos).Where(t => t.Alunos.Any(a => a.Id == id));
                    break;
                case "professores":
                    query = query.Where(t => t.ProfessorId == id);
                    break;
                default:
                    return Enumerable.Empty<Turma?>();
            }

            return await query.ToListAsync();
        }

        public Task<IEnumerable<Turma?>> GetMultipleByIds(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public async Task<Turma> Update(Turma entity)
        {
            var tracker = _context.ChangeTracker.Entries();
            var id = entity.Id;
            var turmaAntiga = await _context.Turmas.AsNoTracking().Include(t => t.Alunos).FirstOrDefaultAsync(t => t.Id == id);

            try
            {
                _context.Update(entity);
                tracker = _context.ChangeTracker.Entries();
                foreach(var entry in tracker)
                {
                    if(entry.Entity is Aluno aluno)
                    {
                        if (turmaAntiga.Alunos.Any(a => a.Id == aluno.Id))
                        {
                            entry.State = EntityState.Detached;
                        }
                    }

                    if(entry.Entity is Dictionary<string,object> dictionary)
                    {
                        var alunoId = dictionary["AlunosId"];
                        var turmaId = dictionary["TurmasId"];
                        if (turmaAntiga.Alunos.Any(aluno => aluno.Id.ToString() == dictionary["AlunosId"].ToString()) && turmaAntiga.Id.ToString() == dictionary["TurmasId"].ToString())
                        {
                            entry.State = EntityState.Detached;
                        }
                    }
                }
                tracker = _context.ChangeTracker.Entries();
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return entity;
        }
    }
}
