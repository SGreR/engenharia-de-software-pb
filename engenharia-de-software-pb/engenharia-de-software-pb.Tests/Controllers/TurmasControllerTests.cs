using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using engenharia_de_software_pb.BLL.Models;
using engenharia_de_software_pb.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using engenharia_de_software_pb.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using engenharia_de_software_pb.turmas.Controllers;

namespace engenharia_de_software_pb.Tests.Controllers
{
    public class TurmasControllerTests
    {
        private readonly TurmasController _turmasController;
        private readonly Mock<IRepository<Turma>> _mockRepository;

        public TurmasControllerTests()
        {

            _mockRepository = new Mock<IRepository<Turma>>();
            _turmasController = new TurmasController(_mockRepository.Object);

        }

        [Fact]
        public async Task GetTurmas_ReturnsListOfTurmas()
        {
            _mockRepository.Setup(repo => repo.GetAll())
                           .ReturnsAsync(new List<Turma> { new Turma { Id = 1, Nome = "Turma Teste 1" }, new Turma { Id = 2, Nome = "Turma Teste 2" } });

            var result = await _turmasController.GetTurmas();

            var actionResult = Assert.IsType<ActionResult<IEnumerable<Turma>>>(result);
            var model = Assert.IsType<List<Turma>>(actionResult.Value);

            Assert.Equal(2, model.Count);
        }

        [Fact]
        public async Task GetTurma_ReturnsNotFoundForInvalidId()
        {
            _mockRepository.Setup(repo => repo.GetById(It.IsAny<int>()))
                           .ReturnsAsync((Turma)null);

            var result = await _turmasController.GetTurma(999);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task PostTurma_ReturnsCreatedAtAction()
        {
            var newTurma = new Turma { Id = 3, Nome = "Nova Turma" };
            _mockRepository.Setup(repo => repo.Create(It.IsAny<Turma>()))
                           .ReturnsAsync(newTurma);

            var result = await _turmasController.PostTurmas(newTurma);

            var actionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var model = Assert.IsType<Turma>(actionResult.Value);

            Assert.Equal(newTurma.Id, model.Id);
        }

        [Fact]
        public async Task DeleteTurma_ReturnsNoContent()
        {
            var newTurma = new Turma { Id = 3, Nome = "Nova Turma" };
            _mockRepository.Setup(repo => repo.GetById(It.IsAny<int>()))
                           .ReturnsAsync(newTurma);

            var result = await _turmasController.DeleteTurma(newTurma.Id);

            var actionResult = Assert.IsType<NoContentResult>(result);
            Assert.Equal(StatusCodes.Status204NoContent, actionResult.StatusCode);
        }

        [Fact]
        public async Task DeleteTurma_ReturnsNotFound()
        {
            _mockRepository.Setup(repo => repo.GetById(It.IsAny<int>()))
                   .ReturnsAsync((Turma)null);

            var result = await _turmasController.DeleteTurma(7);

            var actionResult = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(StatusCodes.Status404NotFound, actionResult.StatusCode);
        }

        [Fact]
        public async Task PutTurma_ReturnsOk()
        {
            var newTurma = new Turma { Id = 3, Nome = "Nova Turma" };
            _mockRepository.Setup(repo => repo.Update(It.IsAny<Turma>()))
                           .ReturnsAsync(newTurma);

            var result = await _turmasController.PutTurmas(newTurma.Id, newTurma);

            var actionResult = Assert.IsType<OkResult>(result);
            Assert.Equal(StatusCodes.Status200OK, actionResult.StatusCode);
        }

        [Fact]
        public async Task PutTurma_ReturnsBadRequest()
        {
            var newTurma = new Turma { Id = 3, Nome = "Nova Turma" };
            _mockRepository.Setup(repo => repo.Update(It.IsAny<Turma>()))
                           .ReturnsAsync(newTurma);

            var result = await _turmasController.PutTurmas(newTurma.Id + 1, newTurma);

            var actionResult = Assert.IsType<BadRequestResult>(result);
            Assert.Equal(StatusCodes.Status400BadRequest, actionResult.StatusCode);
        }
    }
}
