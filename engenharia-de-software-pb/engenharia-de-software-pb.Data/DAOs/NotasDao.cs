using System;
using System.Collections.Generic;
using System.Linq;
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
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            _context.Remove(id);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Notas>> GetAll()
        {
            return await _context.Notas
                .Include(n => n.Aluno)
                .Include(n => n.Reading)
                .Include(n => n.Writing)
                .Include(n => n.Listening)
                .Include(n => n.Grammar)
                .Include(n => n.Speaking)
                .Include(n => n.ClassPerformance)
                .ToListAsync();
        }

        public async Task<IEnumerable<Notas>> GetMultipleByIds(IEnumerable<int> idList)
        {
            var notas = new List<Notas>();
            foreach(var id in idList)
            {
                var nota = await GetById(id);
                notas.Add(nota);
            }
            return notas;
        }

        public async Task<IEnumerable<Notas?>> GetByAlunoId(int id)
        {
            var notasDoAlunoIds = GetAll().Result.Where(n => n.AlunoId == id).Select(n => n.Id);
            return await GetMultipleByIds(notasDoAlunoIds);
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
    }
}
