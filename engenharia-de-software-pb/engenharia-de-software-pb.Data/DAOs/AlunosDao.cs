using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using engenharia_de_software_pb.BLL.Models;
using engenharia_de_software_pb.Data.Interfaces;
using engenharia_de_software_pb.Data.Migrations;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace engenharia_de_software_pb.Data.DAOs
{
    public class AlunosDao : IDao<Aluno>
    {
        private readonly ApplicationDbContext _context;

        public AlunosDao(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<Aluno> Add(Aluno entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(Aluno entity)
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

            public async Task<IEnumerable<Aluno>> GetAll()
        {
            return await _context.Alunos.ToListAsync();
        }

        public Task<IEnumerable<Aluno>> GetByAlunoId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Aluno?> GetById(int id)
        {
            return await _context.Alunos
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public Task<Aluno> GetByIdAsNoTracking(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Aluno?>> GetByRelatedId(string type, int id)
        {
            IQueryable<Aluno> query = _context.Alunos
                .Include(a => a.Turmas);

            switch (type)
            {
                case "turma":
                    query = query.Where(a => a.Turmas.Any(t => t.Id == id));
                    break;
                default:
                    return Enumerable.Empty<Aluno?>();
            }

            return await query.ToListAsync();
        }

        public async Task<Aluno> Update(Aluno entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
