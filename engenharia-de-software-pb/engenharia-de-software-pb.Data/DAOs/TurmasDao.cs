using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using engenharia_de_software_pb.BLL.Models;
using engenharia_de_software_pb.Data.Interfaces;
using engenharia_de_software_pb.Data.Migrations;
using engenharia_de_software_pb.Data.Repositories;
using engenharia_de_software_pb.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace engenharia_de_software_pb.Data.DAOs
{
    public class TurmasDao : IDao<Turma>
    {
        private readonly ApplicationDbContext _context;
        private readonly TurmasService _turmasService;

        public TurmasDao(ApplicationDbContext applicationDbContext, TurmasService turmasService)
        {
            _context = applicationDbContext;
            _turmasService = turmasService;
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
                .OrderByDescending(t => t.Ano)
                .ThenByDescending(t => t.Semestre)
                .ToListAsync();
        }

        public async Task<Turma?> GetById(int id)
        {
            return await _context.Turmas
                .Include(t => t.Alunos)
                .Include(t => t.Professor)
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
            var turmaAntiga = await _context.Turmas
                .AsNoTracking()
                .Include(t => t.Alunos)
                .Include(t => t.Professor)
                .FirstOrDefaultAsync(t => t.Id == entity.Id);

            try
            {
                _context.Update(entity);
                tracker = _context.ChangeTracker.Entries();
                _turmasService.AtualizarTurma(_context, entity, turmaAntiga);
                await _context.SaveChangesAsync();
                tracker = _context.ChangeTracker.Entries();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return entity;
        }
    }
}
