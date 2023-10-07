using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using Moq;
using TeamBuilder.API.Team.Application.Controllers;
using TeamBuilder.DTO.Team.Infrastructure;

namespace TeamBuilder.API.Tests.Team.Application.Controllers
{
    public class TeamControllerTests
    {
        [Fact]
        public async Task AddTeamMember_ReturnNoContent_WhenMemberIsSuccesfulyAdded()
        {
            //arrange
            var loggerStub = new Mock<ILogger<TeamController>>();
            var controller = new TeamController(loggerStub.Object);

            //act
            var response = await controller.AddTeamMember(Guid.NewGuid(), new());

            //assert
            ((IStatusCodeActionResult)response).StatusCode.Should().Be(204);
        }

        [Fact]
        public async Task AddTeamMember_Returns422_WhenMemberDataIsMissing()
        {
            //arrange
            var loggerStub = new Mock<ILogger<TeamController>>();
            var controller = new TeamController(loggerStub.Object);

            //act
            var response = await controller.AddTeamMember(Guid.NewGuid(), null);

            //assert
            ((IStatusCodeActionResult)response).StatusCode.Should().Be(422);
        }


        [Fact]
        public async Task AddTeamMember_Returns400_WhenMemberDataIsInCorrect()
        {
            //arrange
            var loggerStub = new Mock<ILogger<TeamController>>();
            var controller = new TeamController(loggerStub.Object);

            //act
            var response = await controller.AddTeamMember(Guid.NewGuid(), new TeamMemberDto
            {
                Name = "Test Angie",
                NickName = "69",
                Position = "123",
                PhoneNumber = "Sorry, I won't give you this"
            });

            //assert
            ((IStatusCodeActionResult)response).StatusCode.Should().Be(400);
        }
    }
}

