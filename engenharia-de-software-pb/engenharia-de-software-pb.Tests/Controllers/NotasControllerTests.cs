using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using engenharia_de_software_pb.BLL.Models;
using engenharia_de_software_pb.notas.Controllers;
using engenharia_de_software_pb.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using engenharia_de_software_pb.Data.Interfaces;

namespace engenharia_de_software_pb.Tests.Controllers
{
    public class NotasControllerTests
    {
        private readonly NotasController _notasController;
        private readonly Mock<IRepository<Notas>> _mockRepository;

        public NotasControllerTests()
        {
            _mockRepository = new Mock<IRepository<Notas>>();
            _notasController = new NotasController(_mockRepository.Object);
        }

        [Fact]
        public async Task GetNotas_ReturnsListOfNotas()
        {
            _mockRepository.Setup(repo => repo.GetAll())
                           .ReturnsAsync(new List<Notas> { new Notas { Id = 1, AlunoId = 1 }, new Notas { Id = 2, AlunoId = 2 } });

            var result = await _notasController.GetNotas();

            var actionResult = Assert.IsType<ActionResult<IEnumerable<Notas>>>(result);
            var model = Assert.IsType<List<Notas>>(actionResult.Value);

            Assert.Equal(2, model.Count);
        }

        [Fact]
        public async Task GetNotas_ReturnsNotFoundForInvalidId()
        {
            _mockRepository.Setup(repo => repo.GetById(It.IsAny<int>()))
                           .ReturnsAsync((Notas)null);

            var result = await _notasController.GetNotas(999);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task PostNotas_ReturnsCreatedAtAction()
        {
            var newNotas = new Notas { Id = 3, AlunoId = 3 };
            _mockRepository.Setup(repo => repo.Create(It.IsAny<Notas>()))
                           .ReturnsAsync(newNotas);

            var result = await _notasController.PostNotas(newNotas);

            var actionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var model = Assert.IsType<Notas>(actionResult.Value);

            Assert.Equal(newNotas.Id, model.Id);
        }

        [Fact]
        public async Task DeleteNotas_ReturnsNoContent()
        {
            var newNotas = new Notas { Id = 3, AlunoId = 3 };
            _mockRepository.Setup(repo => repo.GetById(It.IsAny<int>()))
                           .ReturnsAsync(newNotas);

            var result = await _notasController.DeleteNotas(newNotas.Id);

            var actionResult = Assert.IsType<NoContentResult>(result);
            Assert.Equal(StatusCodes.Status204NoContent, actionResult.StatusCode);
        }

        [Fact]
        public async Task DeleteNotas_ReturnsNotFound()
        {
            _mockRepository.Setup(repo => repo.GetById(It.IsAny<int>()))
                   .ReturnsAsync((Notas)null);

            var result = await _notasController.DeleteNotas(7);

            var actionResult = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(StatusCodes.Status404NotFound, actionResult.StatusCode);
        }

        [Fact]
        public async Task PutNotas_ReturnsOk()
        {
            var newNotas = new Notas { Id = 3, AlunoId = 3 };
            _mockRepository.Setup(repo => repo.Update(It.IsAny<Notas>()))
                           .ReturnsAsync(newNotas);

            var result = await _notasController.PutNotas(newNotas.Id, newNotas);

            var actionResult = Assert.IsType<OkResult>(result);
            Assert.Equal(StatusCodes.Status200OK, actionResult.StatusCode);
        }

        [Fact]
        public async Task PutNotas_ReturnsBadRequest()
        {
            var newNotas = new Notas { Id = 3, AlunoId = 3 };
            _mockRepository.Setup(repo => repo.Update(It.IsAny<Notas>()))
                           .ReturnsAsync(newNotas);

            var result = await _notasController.PutNotas(newNotas.Id + 1, newNotas);

            var actionResult = Assert.IsType<BadRequestResult>(result);
            Assert.Equal(StatusCodes.Status400BadRequest, actionResult.StatusCode);
        }
    }
}
