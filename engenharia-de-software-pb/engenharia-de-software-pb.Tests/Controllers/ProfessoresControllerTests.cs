using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using engenharia_de_software_pb.BLL.Models;
using engenharia_de_software_pb.Data.Interfaces;
using engenharia_de_software_pb.professores.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace engenharia_de_software_pb.Tests.Controllers
{
    public class ProfessoresControllerTests
    {
        private readonly ProfessoresController _professoresController;
        private readonly Mock<IRepository<Professor>> _mockRepository;

        public ProfessoresControllerTests()
        {

            _mockRepository = new Mock<IRepository<Professor>>();
            _professoresController = new ProfessoresController(_mockRepository.Object);

        }

        [Fact]
        public async Task GetProfessores_ReturnsListOfProfessores()
        {
            _mockRepository.Setup(repo => repo.GetAll())
                           .ReturnsAsync(new List<Professor> { new Professor { Id = 1, Name = "Fulano" }, new Professor { Id = 2, Name = "Ciclano" } });

            var result = await _professoresController.GetProfessores();

            var actionResult = Assert.IsType<ActionResult<IEnumerable<Professor>>>(result);
            var model = Assert.IsType<List<Professor>>(actionResult.Value);

            Assert.Equal(2, model.Count);
        }

        [Fact]
        public async Task GetProfessor_ReturnsNotFoundForInvalidId()
        {
            _mockRepository.Setup(repo => repo.GetById(It.IsAny<int>()))
                           .ReturnsAsync((Professor)null);

            var result = await _professoresController.GetProfessor(999);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task PostProfessor_ReturnsCreatedAtAction()
        {
            var newProfessor = new Professor { Id = 3, Name = "Novo Professor" };
            _mockRepository.Setup(repo => repo.Create(It.IsAny<Professor>()))
                           .ReturnsAsync(newProfessor);

            var result = await _professoresController.PostProfessor(newProfessor);

            var actionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var model = Assert.IsType<Professor>(actionResult.Value);

            Assert.Equal(newProfessor.Id, model.Id);
        }

        [Fact]
        public async Task DeleteProfessor_ReturnsNoContent()
        {
            var newProfessor = new Professor { Id = 3, Name = "Novo Professor" };
            _mockRepository.Setup(repo => repo.GetById(It.IsAny<int>()))
                           .ReturnsAsync(newProfessor);

            var result = await _professoresController.DeleteProfessor(newProfessor.Id);

            var actionResult = Assert.IsType<NoContentResult>(result);
            Assert.Equal(StatusCodes.Status204NoContent, actionResult.StatusCode);
        }

        [Fact]
        public async Task DeleteProfessor_ReturnsNotFound()
        {
            _mockRepository.Setup(repo => repo.GetById(It.IsAny<int>()))
                   .ReturnsAsync((Professor)null);

            var result = await _professoresController.DeleteProfessor(7);

            var actionResult = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(StatusCodes.Status404NotFound, actionResult.StatusCode);
        }

        [Fact]
        public async Task PutProfessor_ReturnsOk()
        {
            var newProfessor = new Professor { Id = 3, Name = "Novo Professor" };
            _mockRepository.Setup(repo => repo.Update(It.IsAny<Professor>()))
                           .ReturnsAsync(newProfessor);

            var result = await _professoresController.PutProfessor(newProfessor.Id, newProfessor);

            var actionResult = Assert.IsType<OkResult>(result);
            Assert.Equal(StatusCodes.Status200OK, actionResult.StatusCode);
        }

        [Fact]
        public async Task PutProfessor_ReturnsBadRequest()
        {
            var newProfessor = new Professor { Id = 3, Name = "Novo Professor" };
            _mockRepository.Setup(repo => repo.Update(It.IsAny<Professor>()))
                           .ReturnsAsync(newProfessor);

            var result = await _professoresController.PutProfessor(newProfessor.Id + 1, newProfessor);

            var actionResult = Assert.IsType<BadRequestResult>(result);
            Assert.Equal(StatusCodes.Status400BadRequest, actionResult.StatusCode);
        }
    }
}
