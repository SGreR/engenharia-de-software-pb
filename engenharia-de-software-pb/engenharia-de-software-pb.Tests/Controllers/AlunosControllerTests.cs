using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using engenharia_de_software_pb.BLL.Models;
using engenharia_de_software_pb.Server.Controllers;
using engenharia_de_software_pb.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using engenharia_de_software_pb.Data.Interfaces;
using Microsoft.AspNetCore.Http;

namespace engenharia_de_software_pb.Tests.Controllers
{
    public class AlunosControllerTests
    {
        private readonly AlunosController _alunosController;
        private readonly Mock<IRepository<Aluno>> _mockRepository;

        public AlunosControllerTests()
        {

            _mockRepository = new Mock<IRepository<Aluno>>();
            _alunosController = new AlunosController(_mockRepository.Object);

        }

        [Fact]
        public async Task GetAlunos_ReturnsListOfAlunos()
        {
            _mockRepository.Setup(repo => repo.GetAll())
                           .ReturnsAsync(new List<Aluno> { new Aluno { Id = 1, Name = "Fulano" }, new Aluno { Id = 2, Name = "Ciclano" } });

            var result = await _alunosController.GetAlunos();

            var actionResult = Assert.IsType<ActionResult<IEnumerable<Aluno>>>(result);
            var model = Assert.IsType<List<Aluno>>(actionResult.Value);

            Assert.Equal(2, model.Count);
        }

        [Fact]
        public async Task GetAluno_ReturnsNotFoundForInvalidId()
        {
            _mockRepository.Setup(repo => repo.GetById(It.IsAny<int>()))
                           .ReturnsAsync((Aluno)null);

            var result = await _alunosController.GetAluno(999);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task PostAluno_ReturnsCreatedAtAction()
        {
            var newAluno = new Aluno { Id = 3, Name = "Novo Aluno" };
            _mockRepository.Setup(repo => repo.Create(It.IsAny<Aluno>()))
                           .ReturnsAsync(newAluno);

            var result = await _alunosController.PostAluno(newAluno);

            var actionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var model = Assert.IsType<Aluno>(actionResult.Value);

            Assert.Equal(newAluno.Id, model.Id);
        }

        [Fact]
        public async Task DeleteAluno_ReturnsOk()
        {
            var newAluno = new Aluno { Id = 3, Name = "Novo Aluno" };
            _mockRepository.Setup(repo => repo.GetById(It.IsAny<int>()))
                           .ReturnsAsync(newAluno);

            var result = await _alunosController.DeleteAluno(newAluno.Id);

            var actionResult = Assert.IsType<NoContentResult>(result);
            Assert.Equal(StatusCodes.Status204NoContent, actionResult.StatusCode);
        }

        [Fact]
        public async Task DeleteAluno_ReturnsNotFound()
        {
            _mockRepository.Setup(repo => repo.GetById(It.IsAny<int>()))
                   .ReturnsAsync((Aluno)null);

            var result = await _alunosController.DeleteAluno(7);

            var actionResult = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(StatusCodes.Status404NotFound, actionResult.StatusCode);
        }

        [Fact]
        public async Task PutAlunos_ReturnsOk()
        {
            var newAluno = new Aluno { Id = 3, Name = "Novo Aluno" };
            _mockRepository.Setup(repo => repo.Update(It.IsAny<Aluno>()))
                           .ReturnsAsync(newAluno);

            var result = await _alunosController.PutAlunos(newAluno.Id, newAluno);

            var actionResult = Assert.IsType<OkResult>(result);
            Assert.Equal(StatusCodes.Status200OK, actionResult.StatusCode);
        }

        [Fact]
        public async Task PutAlunos_ReturnsBadRequest()
        {
            var newAluno = new Aluno { Id = 3, Name = "Novo Aluno" };
            _mockRepository.Setup(repo => repo.Update(It.IsAny<Aluno>()))
                           .ReturnsAsync(newAluno);

            var result = await _alunosController.PutAlunos(newAluno.Id + 1, newAluno);

            var actionResult = Assert.IsType<BadRequestResult>(result);
            Assert.Equal(StatusCodes.Status400BadRequest, actionResult.StatusCode);
        }
    }
}
