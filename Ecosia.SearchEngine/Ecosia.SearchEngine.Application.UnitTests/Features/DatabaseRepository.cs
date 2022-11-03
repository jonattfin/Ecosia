using System.Collections.Immutable;
using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using Ecosia.SearchEngine.Application.Profiles;
using Ecosia.SearchEngine.Domain.Entities;
using Moq;

namespace Ecosia.SearchEngine.Application.UnitTests.Features;

public class DatabaseRepository
{
    public DatabaseRepository()
    {
        var configurationProvider = new MapperConfiguration(cfg
            =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        Mapper = configurationProvider.CreateMapper();

        Projects = CreateProjects();
        ProjectRepositoryMock = CreateProjectRepositoryMock(Projects);

        Reports = CreateReports();
        ReportRepositoryMock = CreateReportRepositoryMock(Reports);
    }

    public IMapper Mapper { get; }

    public List<Project> Projects { get; }

    public Mock<IProjectRepository> ProjectRepositoryMock { get; }

    public List<Report> Reports { get; }

    public Mock<IReportRepository> ReportRepositoryMock { get; }

    private static List<Project> CreateProjects()
    {
        return Enumerable.Range(1, 4).Select(element => new Project()
        {
            Id = Guid.NewGuid(),
            Name = $"Name {element}",
        }).ToList();
    }

    private static List<Report> CreateReports()
    {
        return Enumerable.Range(1, 4).Select(element => new Report()
        {
            Id = Guid.NewGuid(),
            Month = element.ToString(),
            Year = 2022,
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

    private static Mock<IReportRepository> CreateReportRepositoryMock(IList<Report> reports)
    {
        var mockRepository = new Mock<IReportRepository>();

        mockRepository.Setup(repo =>
            repo.ListAllAsync()).ReturnsAsync(reports.ToImmutableList());

        mockRepository.Setup(repo =>
            repo.GetByIdAsync(reports[0].Id)).ReturnsAsync(reports[0]);

        mockRepository.Setup(repo => repo.AddAsync(It.IsAny<Report>()))
            .ReturnsAsync((Report report) =>
            {
                reports.Add(report);
                return report;
            });

        mockRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Report>()))
            .Callback((Report report) =>
            {
                var toUpdate = reports.First(p => p.Id == report.Id);
                toUpdate.TotalIncome = report.TotalIncome;
            });

        mockRepository.Setup(repo => repo.DeleteAsync(It.IsAny<Report>()))
            .Callback((Report report) => { reports.Remove(report); });

        return mockRepository;
    }
}