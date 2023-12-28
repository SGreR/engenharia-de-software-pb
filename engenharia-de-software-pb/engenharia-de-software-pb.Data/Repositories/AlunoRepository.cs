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
        private readonly AlunosDao _alunosDao;
        private readonly NotasRepository _notasRepository;

        public AlunoRepository(AlunosDao alunosDao, NotasRepository notasRepository)
        {
            _alunosDao = alunosDao;
            _notasRepository = notasRepository;
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
                await _alunosDao.Delete(entity.Id);
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
                if (aluno != null)
                {
                    var notasDoAluno = await _notasRepository.GetByAlunoId(id);
                    aluno.PopularNotas(notasDoAluno);
                }
                return aluno;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
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
