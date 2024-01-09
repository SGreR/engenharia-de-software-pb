using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using engenharia_de_software_pb.BLL.Models;
using engenharia_de_software_pb.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

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
                .Include(a => a.Notas)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Aluno> Update(Aluno entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
