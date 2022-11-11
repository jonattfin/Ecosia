using System.Collections.Immutable;
using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Infrastructure;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using Ecosia.SearchEngine.Application.Profiles;
using Ecosia.SearchEngine.Application.Seed;
using Ecosia.SearchEngine.Domain.Entities;
using Moq;

namespace Ecosia.SearchEngine.Application.UnitTests.Features;

public class RepositoryFacade
{
    public RepositoryFacade()
    {
        var configurationProvider = new MapperConfiguration(cfg
            =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        Mapper = configurationProvider.CreateMapper();

        Inventory = InventoryFactory.CreateInventory();

        ProjectRepositoryMock = CreateProjectRepositoryMock(Inventory.Projects);
        ReportRepositoryMock = CreateReportRepositoryMock(Inventory.Reports);
        SearchRepositoryMock = CreateSearchRepositoryMock(Inventory.Searches);
        CountryRepositoryMock = CreateCountryRepositoryMock(Inventory.Countries);
        CategoryRepositoryMock = CreateCategoryRepositoryMock(Inventory.Categories);
    }

    public IMapper Mapper { get; }

    public IInventory Inventory { get; }

    public Mock<IProjectRepository> ProjectRepositoryMock { get; }

    public Mock<IReportRepository> ReportRepositoryMock { get; }

    public Mock<ISearchRepository> SearchRepositoryMock { get; }

    public Mock<ICountryRepository> CountryRepositoryMock { get; }

    public Mock<ICategoryRepository> CategoryRepositoryMock { get; }

    private static Mock<IProjectRepository> CreateProjectRepositoryMock(ICollection<Project> projects)
    {
        var mockProjectRepository = new Mock<IProjectRepository>();

        mockProjectRepository.Setup(repo =>
            repo.ListAllAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(projects.ToImmutableList());

        mockProjectRepository.Setup(repo => repo.CountAsync()).ReturnsAsync(projects.Count);

        mockProjectRepository.Setup(repo =>
            repo.GetByIdAsync(projects.First().Id)).ReturnsAsync(projects.First);

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

    private static Mock<IReportRepository> CreateReportRepositoryMock(ICollection<Report> reports)
    {
        var mockRepository = new Mock<IReportRepository>();

        mockRepository.Setup(repo =>
            repo.ListAllAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(reports.ToImmutableList());

        mockRepository.Setup(repo => repo.CountAsync()).ReturnsAsync(reports.Count);

        mockRepository.Setup(repo =>
            repo.GetByIdAsync(reports.First().Id)).ReturnsAsync(reports.First);

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

    private static Mock<ISearchRepository> CreateSearchRepositoryMock(IList<Domain.Entities.Search> searches)
    {
        var mockRepository = new Mock<ISearchRepository>();

        mockRepository.Setup(repo =>
            repo.ListAllAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(searches);

        return mockRepository;
    }

    private static Mock<ICategoryRepository> CreateCategoryRepositoryMock(IList<Category> categories)
    {
        var mockRepository = new Mock<ICategoryRepository>();

        mockRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(categories.ToList());

        return mockRepository;
    }

    private static Mock<ICountryRepository> CreateCountryRepositoryMock(IList<Country> countries)
    {
        var mockRepository = new Mock<ICountryRepository>();

        mockRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(countries.ToList());

        return mockRepository;
    }
}