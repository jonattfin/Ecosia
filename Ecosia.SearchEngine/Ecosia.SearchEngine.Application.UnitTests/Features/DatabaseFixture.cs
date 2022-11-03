using System.Collections.Immutable;
using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using Ecosia.SearchEngine.Application.Profiles;
using Ecosia.SearchEngine.Domain.Entities;
using Moq;
using Xunit.Abstractions;

namespace Ecosia.SearchEngine.Application.UnitTests.Features;

public class DatabaseFixture
{
    public DatabaseFixture()
    {
        var configurationProvider = new MapperConfiguration(cfg
            =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        Mapper = configurationProvider.CreateMapper();

        Projects = CreateProjects();
        ProjectRepositoryMock = CreateProjectRepositoryMock(Projects);
    }

    public IMapper Mapper { get; }

    public List<Project> Projects { get; }

    public Mock<IProjectRepository> ProjectRepositoryMock { get; }

    private static List<Project> CreateProjects()
    {
        return Enumerable.Range(1, 4).Select(element => new Project()
        {
            Id = Guid.NewGuid(),
            Name = $"Name {element}",
        }).ToList();
    }

    private static Mock<IProjectRepository> CreateProjectRepositoryMock(IList<Project> projects)
    {
        var mockProjectRepository = new Mock<IProjectRepository>();

        mockProjectRepository.Setup(repo =>
            repo.ListAllAsync()).ReturnsAsync(projects.ToImmutableList());

        mockProjectRepository.Setup(repo =>
            repo.GetByIdAsync(projects[0].Id)).ReturnsAsync(projects[0]);

        mockProjectRepository.Setup(repo => repo.AddAsync(It.IsAny<Project>()))
            .ReturnsAsync((Project project) =>
            {
                projects.Add(project);
                return project;
            });

        mockProjectRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Project>()))
            .Callback((Project project) =>
            {
                var toUpdateProject = projects.First(p => p.Id == project.Id);
                toUpdateProject.Name = project.Name;
            });

        mockProjectRepository.Setup(repo => repo.DeleteAsync(It.IsAny<Project>()))
            .Callback((Project project) => { projects.Remove(project); });

        return mockProjectRepository;
    }
}