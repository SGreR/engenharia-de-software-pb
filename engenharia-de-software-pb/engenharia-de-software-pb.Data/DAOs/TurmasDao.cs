﻿using System;
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
            IQueryable<Turma> query = _context.Turmas
                .Include(t => t.Alunos);

            switch (type)
            {
                case "aluno":
                    query = query.Where(t => t.Alunos.Any(a => a.Id == id));
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
            try
            {
                var turmaAntiga = await GetById(entity.Id);
                turmaAntiga.Nome = entity.Nome;
                _alunosService.AtualizarAlunos(turmaAntiga, entity);

                entity.Id = 0;
                _context.Entry(entity).State = EntityState.Detached;
                _context.ChangeTracker.Clear();

                _context.Update(turmaAntiga);
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
