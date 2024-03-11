using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using engenharia_de_software_pb.BLL.Models;
using engenharia_de_software_pb.Data.Interfaces;

namespace engenharia_de_software_pb.Data.Repositories
{
    public class ProfessorRepository : IRepository<Professor>
    {
        public readonly IDao<Professor> _professoresDao;

        public ProfessorRepository(IDao<Professor> turmasDao)
        {
            _professoresDao = turmasDao;
        }

        public async Task<Professor> Create(Professor entity)
        {
            try
            {
                await _professoresDao.Add(entity);
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return entity;
            }
        }

        public async Task<bool> Delete(Professor entity)
        {
            try
            {
                await _professoresDao.Delete(entity);
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
            try
            {
                return await _professoresDao.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Enumerable.Empty<Professor>();
            }
        }

        public async Task<Professor?> GetById(int id)
        {
            try
            {
                return await _professoresDao.GetById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<IEnumerable<Professor>> GetByRelatedId(string type, int id)
        {
            try
            {
                return await _professoresDao.GetByRelatedId(type, id);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Enumerable.Empty<Professor>();
            }
        }

        public Task<IEnumerable<Professor?>> GetMultipleByIds(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public async Task<Professor> Update(Professor entity)
        {
            try
            {
                return await _professoresDao.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return entity;
            }
        }
    }
}
