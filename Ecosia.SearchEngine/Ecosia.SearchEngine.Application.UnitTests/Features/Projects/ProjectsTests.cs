using Ecosia.SearchEngine.Application.Contracts.Infrastructure;
using Ecosia.SearchEngine.Application.Features.Projects.Commands;
using Ecosia.SearchEngine.Application.Features.Projects.Queries;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace Ecosia.SearchEngine.Application.UnitTests.Features.Projects;

public class ProjectsTests
{
    private readonly UnitOfWorkFacade _unitOfWorkFacade;

    public ProjectsTests()
    {
        _unitOfWorkFacade = new UnitOfWorkFacade();
    }

    [Fact]
    public async Task GetProjectsListTest()
    {
        // Arrange
        var handler = new GetProjectsListQueryHandler(_unitOfWorkFacade.UnitOfWorkMock.Object,
            _unitOfWorkFacade.Mapper);

        // Act
        var result = await handler.Handle(new GetProjectsListQuery(1, 10), CancellationToken.None);

        // Assert
        result.Should().BeOfType<PagedProjectsListVm>();
        result.Count.Should().Be(4);
    }

    [Fact]
    public async Task GetProjectsDetailsTest()
    {
        // Arrange
        var query = new GetProjectDetailQuery(_unitOfWorkFacade.Inventory.Projects.First().Id);
        var handler = new GetProjectDetailQueryHandler(_unitOfWorkFacade.UnitOfWorkMock.Object,
            _unitOfWorkFacade.Mapper);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().BeOfType<ProjectDetailVm>();
        result.Id.Should().Be(query.Id);
    }

    [Fact]
    public async Task CreateProjectTest()
    {
        // Arrange
        var emailServiceMock = new Mock<IEmailService>();
        var loggerMock = new Mock<ILogger<CreateProjectCommandHandler>>();
        var handler = new CreateProjectCommandHandler(_unitOfWorkFacade.UnitOfWorkMock.Object, _unitOfWorkFacade.Mapper,
            emailServiceMock.Object, loggerMock.Object);

        // Act
        var command = new CreateProjectCommand { Name = "new project" };
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        _unitOfWorkFacade.Inventory.Projects.Count().Should().Be(5);
    }

    [Fact]
    public async Task UpdateProjectTest()
    {
        // Arrange
        var handler = new UpdateProjectCommandHandler(_unitOfWorkFacade.UnitOfWorkMock.Object, _unitOfWorkFacade.Mapper);

        // Act
        var command = new UpdateProjectCommand { Id = _unitOfWorkFacade.Inventory.Projects.First().Id, Name = "Updated Name" };
        await handler.Handle(command, CancellationToken.None);

        // Assert
        _unitOfWorkFacade.Inventory.Projects.First().Name.Should().Be("Updated Name");
    }

    [Fact]
    public async Task DeleteProjectTest()
    {
        // Arrange
        var handler = new DeleteProjectCommandHandler(_unitOfWorkFacade.UnitOfWorkMock.Object, _unitOfWorkFacade.Mapper);

        // Act
        var command = new DeleteProjectCommand(_unitOfWorkFacade.Inventory.Projects.First().Id);
        await handler.Handle(command, CancellationToken.None);

        // Assert
        _unitOfWorkFacade.Inventory.Projects.Count().Should().Be(3);
    }
}