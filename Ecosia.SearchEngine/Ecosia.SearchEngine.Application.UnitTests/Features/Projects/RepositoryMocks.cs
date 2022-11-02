using Ecosia.SearchEngine.Application.Contracts.Persistence;
using Ecosia.SearchEngine.Domain.Entities;
using Moq;

namespace Ecosia.SearchEngine.Application.UnitTests.Features.Projects;

public class RepositoryMocks
{
    public List<Project> Projects { get; } = GetProjects();

    public Mock<IAsyncRepository<Project>> GetProjectRepositoryMock()
    {
        var mockProjectRepository = new Mock<IAsyncRepository<Project>>();
        mockProjectRepository.Setup(repo =>
            repo.ListAllAsync()).ReturnsAsync(Projects);
        
        mockProjectRepository.Setup(repo =>
            repo.GetByIdAsync(Projects.First().Id)).ReturnsAsync(Projects.First());

        return mockProjectRepository;
    }

    private static List<Project> GetProjects()
    {
        return Enumerable.Range(1, 4).Select(element => new Project()
        {
            Id = Guid.NewGuid(),
            Name = $"Name {element}",
        }).ToList();
    }
}