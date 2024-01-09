using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using engenharia_de_software_pb.BLL.Models;
using engenharia_de_software_pb.Data.Interfaces;
using engenharia_de_software_pb.Data.Repositories;

namespace engenharia_de_software_pb.Tests.Repositories
{
    public class AlunoRepositoryTests
    {
        private readonly AlunoRepository _alunoRepository;
        private readonly Mock<IDao<Aluno>> _mockAlunosDao;

        public AlunoRepositoryTests()
        {
            _mockAlunosDao = new Mock<IDao<Aluno>>();
            _alunoRepository = new AlunoRepository(_mockAlunosDao.Object);
        }

        [Fact]
        public async Task CreateAluno_ReturnsAluno()
        {
            var newAluno = new Aluno { Id = 1, Name = "Fulano" };
            _mockAlunosDao.Setup(dao => dao.Add(It.IsAny<Aluno>()))
                          .ReturnsAsync(newAluno);

            var result = await _alunoRepository.Create(newAluno);

            Assert.Equal(newAluno, result);
        }

        [Fact]
        public async Task DeleteAluno_ReturnsTrue()
        {
            var existingAluno = new Aluno { Id = 1, Name = "Fulano" };
            _mockAlunosDao.Setup(dao => dao.Delete(It.IsAny<Aluno>()))
                          .ReturnsAsync(true);

            var result = await _alunoRepository.Delete(existingAluno);

            Assert.True(result);
        }

        [Fact]
        public async Task GetAllAlunos_ReturnsListOfAlunos()
        {
            var alunosList = new List<Aluno> { new Aluno { Id = 1, Name = "Fulano" }, new Aluno { Id = 2, Name = "Ciclano" } };
            _mockAlunosDao.Setup(dao => dao.GetAll())
                          .ReturnsAsync(alunosList);

            var result = await _alunoRepository.GetAll();

            Assert.Equal(alunosList, result);
        }

        [Fact]
        public async Task GetById_ReturnsAluno()
        {
            var existingAluno = new Aluno { Id = 1, Name = "Fulano" };
            _mockAlunosDao.Setup(dao => dao.GetById(It.IsAny<int>()))
                          .ReturnsAsync(existingAluno);

            var result = await _alunoRepository.GetById(existingAluno.Id);

            Assert.Equal(existingAluno, result);
        }

        [Fact]
        public async Task UpdateAluno_ReturnsAluno()
        {
            var existingAluno = new Aluno { Id = 1, Name = "Fulano" };
            _mockAlunosDao.Setup(dao => dao.Update(It.IsAny<Aluno>()))
                          .ReturnsAsync(existingAluno);

            var result = await _alunoRepository.Update(existingAluno);

            Assert.Equal(existingAluno, result);
        }
    }
}
