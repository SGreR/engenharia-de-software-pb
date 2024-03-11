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
    public class ProfessoresDao : IDao<Professor>
    {
        private readonly ApplicationDbContext _context;

        public ProfessoresDao(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<Professor> Add(Professor entity)
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

        public async Task<bool> Delete(Professor entity)
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

        public async Task<IEnumerable<Professor>> GetAll()
        {
            return await _context.Professores
                .ToListAsync();
        }

        public async Task<Professor?> GetById(int id)
        {
            return await _context.Professores
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Professor?>> GetByRelatedId(string type, int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Professor?>> GetMultipleByIds(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public async Task<Professor> Update(Professor entity)
        {
            try
            {
                _context.Update(entity);
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
