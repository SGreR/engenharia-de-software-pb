using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using engenharia_de_software_pb.BLL.Models;
using engenharia_de_software_pb.Data.DAOs;
using engenharia_de_software_pb.Data.Interfaces;

namespace engenharia_de_software_pb.Data.Repositories
{
    public class TurmasRepository : IRepository<Turma>
    {
        public readonly IDao<Turma> _turmasDao;

        public TurmasRepository(IDao<Turma> turmasDao)
        {
            _turmasDao = turmasDao;
        }

        public async Task<Turma> Create(Turma entity)
        {
            try
            {
                await _turmasDao.Add(entity);
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return entity;
            }
        }

        public async Task<bool> Delete(Turma entity)
        {
            try
            {
                await _turmasDao.Delete(entity);
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
            try
            {
                return await _turmasDao.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Enumerable.Empty<Turma>();
            }
        }

        public async Task<Turma?> GetById(int id)
        {
            try
            {
                return await _turmasDao.GetById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<IEnumerable<Turma>> GetByRelatedId(string type, int id)
        {
            try
            {
                return await _turmasDao.GetByRelatedId(type, id);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Enumerable.Empty<Turma>();
            }
        }

        public async Task<Turma> Update(Turma entity)
        {
            try
            {
                return await _turmasDao.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return entity;
            }
        }
    }
}
