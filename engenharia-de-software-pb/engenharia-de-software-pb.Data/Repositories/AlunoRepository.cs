using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using engenharia_de_software_pb.BLL.Factories;
using engenharia_de_software_pb.BLL.Models;
using engenharia_de_software_pb.Data.DAOs;
using engenharia_de_software_pb.Data.Interfaces;

namespace engenharia_de_software_pb.Data.Repositories
{
    public class AlunoRepository : IRepository<Aluno>
    {
        private readonly IDao<Aluno> _alunosDao;

        public AlunoRepository(IDao<Aluno> alunosDao)
        {
            _alunosDao = alunosDao;
        }
        public async Task<Aluno> Create(Aluno entity)
        {
            try
            {
                await _alunosDao.Add(entity);
                return entity;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return entity;
            }
            
        }

        public async Task<bool> Delete(Aluno entity)
        {
            try
            {
                await _alunosDao.Delete(entity);
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
            try
            {
                return await _alunosDao.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Enumerable.Empty<Aluno>();
            }
        }

        public async Task<Aluno?> GetById(int id)
        {
            try
            {
                var aluno = await _alunosDao.GetById(id);
                return aluno;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<IEnumerable<Aluno>> GetByRelatedId(string type, int id)
        {
            try
            {
                return await _alunosDao.GetByRelatedId(type, id);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Enumerable.Empty<Aluno>();
            }
        }

        public async Task<IEnumerable<Aluno?>> GetMultipleByIds(IEnumerable<int> ids)
        {
            try
            {
                return await _alunosDao.GetMultipleByIds(ids);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Enumerable.Empty<Aluno>();
            }
        }

        public async Task<Aluno> Update(Aluno entity)
        {
            try
            {
                return await _alunosDao.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return entity;
            }
        }

        
    }
}
