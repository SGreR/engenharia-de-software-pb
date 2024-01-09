using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using engenharia_de_software_pb.BLL.Models;
using engenharia_de_software_pb.Data.Interfaces;
using engenharia_de_software_pb.Data.Repositories;
using Moq;
using Xunit;

namespace engenharia_de_software_pb.Tests.Repositories
{
    public class NotasRepositoryTests
    {
        private readonly NotasRepository _notasRepository;
        private readonly Mock<IDao<Notas>> _mockNotasDao;

        public NotasRepositoryTests()
        {
            _mockNotasDao = new Mock<IDao<Notas>>();
            _notasRepository = new NotasRepository(_mockNotasDao.Object);
        }

        [Fact]
        public async Task CreateNotas_ReturnsNotas()
        {
            var newNotas = new Notas { Id = 1, AlunoId = 1 };
            _mockNotasDao.Setup(dao => dao.Add(It.IsAny<Notas>()))
                          .ReturnsAsync(newNotas);

            var result = await _notasRepository.Create(newNotas);

            Assert.Equal(newNotas, result);
        }

        [Fact]
        public async Task DeleteNotas_ReturnsTrue()
        {
            var existingNotas = new Notas { Id = 1, AlunoId = 1 };
            _mockNotasDao.Setup(dao => dao.Delete(It.IsAny<Notas>()))
                          .ReturnsAsync(true);

            var result = await _notasRepository.Delete(existingNotas);

            Assert.True(result);
        }

        [Fact]
        public async Task GetAllNotas_ReturnsListOfNotas()
        {
            var notasList = new List<Notas> { new Notas { Id = 1, AlunoId = 1 }, new Notas { Id = 2, AlunoId = 2 } };
            _mockNotasDao.Setup(dao => dao.GetAll())
                          .ReturnsAsync(notasList);

            var result = await _notasRepository.GetAll();

            Assert.Equal(notasList, result);
        }

        [Fact]
        public async Task GetById_ReturnsNotas()
        {
            var existingNotas = new Notas { Id = 1, AlunoId = 1 };
            _mockNotasDao.Setup(dao => dao.GetById(It.IsAny<int>()))
                          .ReturnsAsync(existingNotas);

            var result = await _notasRepository.GetById(existingNotas.Id);

            Assert.Equal(existingNotas, result);
        }

        [Fact]
        public async Task UpdateNotas_ReturnsNotas()
        {
            var existingNotas = new Notas { Id = 1, AlunoId = 1 };
            _mockNotasDao.Setup(dao => dao.Update(It.IsAny<Notas>()))
                          .ReturnsAsync(existingNotas);

            var result = await _notasRepository.Update(existingNotas);

            Assert.Equal(existingNotas, result);
        }
    }
}
