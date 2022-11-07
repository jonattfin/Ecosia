using Ecosia.SearchEngine.Application.Contracts.Infrastructure;
using Ecosia.SearchEngine.Application.Features.Projects.Commands;
using Ecosia.SearchEngine.Application.Features.Projects.Queries;
using Moq;
using Shouldly;

namespace Ecosia.SearchEngine.Application.UnitTests.Features.Projects;

public class ProjectsTests
{
    private readonly RepositoryFacade _repositoryFacade;

    public ProjectsTests()
    {
        _repositoryFacade = new RepositoryFacade();
    }

    [Fact]
    public async Task GetProjectsListTest()
    {
        // Arrange
        var handler = new GetProjectsListQueryHandler(_repositoryFacade.ProjectRepositoryMock.Object,
            _repositoryFacade.Mapper);

        // Act
        var result = await handler.Handle(new GetProjectsListQuery(), CancellationToken.None);

        // Assert
        result.ShouldBeOfType<List<ProjectListVm>>();
        result.Count.ShouldBe(4);
    }

    [Fact]
    public async Task GetProjectsDetailsTest()
    {
        // Arrange
        var query = new GetProjectDetailQuery(_repositoryFacade.Inventory.Projects.First().Id);
        var handler = new GetProjectDetailQueryHandler(_repositoryFacade.ProjectRepositoryMock.Object,
            _repositoryFacade.Mapper);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.ShouldBeOfType<ProjectDetailVm>();
        result.Id.ShouldBe(query.Id);
    }

    [Fact]
    public async Task CreateProjectTest()
    {
        // Arrange
        var emailServiceMock = new Mock<IEmailService>();
        var handler = new CreateProjectCommandHandler(_repositoryFacade.ProjectRepositoryMock.Object, _repositoryFacade.Mapper,
            emailServiceMock.Object);

        // Act
        var command = new CreateProjectCommand { Name = "new project" };
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.ShouldBeOfType<Guid>();
        _repositoryFacade.Inventory.Projects.Count.ShouldBe(5);
    }

    [Fact]
    public async Task UpdateProjectTest()
    {
        // Arrange
        var handler = new UpdateProjectCommandHandler(_repositoryFacade.ProjectRepositoryMock.Object, _repositoryFacade.Mapper);

        // Act
        var command = new UpdateProjectCommand { Id = _repositoryFacade.Inventory.Projects[0].Id, Name = "Updated Name" };
        await handler.Handle(command, CancellationToken.None);

        // Assert
        _repositoryFacade.Inventory.Projects[0].Name.ShouldBe("Updated Name");
    }

    [Fact]
    public async Task DeleteProjectTest()
    {
        // Arrange
        var handler = new DeleteProjectCommandHandler(_repositoryFacade.ProjectRepositoryMock.Object, _repositoryFacade.Mapper);

        // Act
        var command = new DeleteProjectCommand(_repositoryFacade.Inventory.Projects[0].Id);
        await handler.Handle(command, CancellationToken.None);

        // Assert
        _repositoryFacade.Inventory.Projects.Count.ShouldBe(3);
    }
}