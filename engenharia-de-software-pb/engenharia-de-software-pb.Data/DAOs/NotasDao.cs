using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using engenharia_de_software_pb.BLL.Models;
using engenharia_de_software_pb.Data.Interfaces;
using engenharia_de_software_pb.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace engenharia_de_software_pb.Data.DAOs
{
    public class NotasDao : IDao<Notas>
    {
        private readonly ApplicationDbContext _context;

        public NotasDao(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public async Task<Notas> Add(Notas entity)
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

        public async Task<bool> Delete(Notas entity)
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

            public async Task<IEnumerable<Notas>> GetAll()
        {
            return await _context.Notas
                .Include(n => n.Aluno)
                .Include(n => n.Turma)
                .Include(n => n.Reading)
                .Include(n => n.Writing)
                .Include(n => n.Listening)
                .Include(n => n.Grammar)
                .Include(n => n.Speaking)
                .Include(n => n.ClassPerformance)
                .ToListAsync();
        }

        public async Task<IEnumerable<Notas?>> GetByRelatedId(string type, int id)
        {
            IQueryable<Notas> query = _context.Notas
                .Include(n => n.Aluno)
                .Include(n => n.Turma)
                .Include(n => n.Reading)
                .Include(n => n.Writing)
                .Include(n => n.Listening)
                .Include(n => n.Grammar)
                .Include(n => n.Speaking)
                .Include(n => n.ClassPerformance);

            switch(type)
            {
                case "aluno": 
                    query = query.Where(n => n.AlunoId == id);
                    break;
                case "turma":
                    query = query.Where(n => n.TurmaId == id);
                    break;
                default:
                    return Enumerable.Empty<Notas?>();
            }

            return await query.ToListAsync();
        }

        public async Task<Notas?> GetById(int id)
        {
            var notas = await _context.Notas
                .Include(n => n.Aluno)
                .Include(n => n.Reading)
                .Include(n => n.Writing)
                .Include(n => n.Listening)
                .Include(n => n.Grammar)
                .Include(n => n.Speaking)
                .Include(n => n.ClassPerformance)
                .FirstOrDefaultAsync(n => n.Id == id);
            return notas;
        }

        public async Task<Notas> Update(Notas entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public Task<Notas> GetByIdAsNoTracking(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Notas?>> GetMultipleByIds(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
