using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Infrastructure;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using Ecosia.SearchEngine.Application.Profiles;
using Ecosia.SearchEngine.Application.Seed;
using Ecosia.SearchEngine.Domain.Entities;
using Moq;

namespace Ecosia.SearchEngine.Application.UnitTests.Features;

public class UnitOfWorkFacade
{
    public UnitOfWorkFacade()
    {
        var configurationProvider = new MapperConfiguration(cfg
            =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        Mapper = configurationProvider.CreateMapper();
        Inventory = InventoryFactory.CreateInventory();

        UnitOfWorkMock = CreateUnitOfWorkMock(Inventory);
       
        SearchRepositoryMock = CreateSearchRepositoryMock(Inventory.Searches);
    }

    public IMapper Mapper { get; }

    public IInventory Inventory { get; }

    public Mock<IUnitOfWork> UnitOfWorkMock { get; }
    
    public Mock<ISearchRepository> SearchRepositoryMock { get; }

    private static Mock<IUnitOfWork> CreateUnitOfWorkMock(IInventory inventory)
    {
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        var projectRepositoryMock = CreateProjectRepositoryMock(inventory.Projects);
        mockUnitOfWork.Setup(work => work.ProjectRepository).Returns(projectRepositoryMock.Object);
        
        var reportRepositoryMock = CreateReportRepositoryMock(inventory.Reports);
        mockUnitOfWork.Setup(work => work.ReportRepository).Returns(reportRepositoryMock.Object);
        
        var countryRepositoryMock = CreateCountryRepositoryMock(inventory.Countries);
        mockUnitOfWork.Setup(work => work.CountryRepository).Returns(countryRepositoryMock.Object);
        
        var categoryRepositoryMock = CreateCategoryRepositoryMock(inventory.Categories);
        mockUnitOfWork.Setup(work => work.CategoryRepository).Returns(categoryRepositoryMock.Object);
        
        return mockUnitOfWork;
    }
    
    private static Mock<IProjectRepository> CreateProjectRepositoryMock(ICollection<Project> projects)
    {
        var mockProjectRepository = new Mock<IProjectRepository>();

        mockProjectRepository.Setup(repo =>
            repo.ListAllAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync((projects, projects.Count));

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
            repo.ListAllAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync((reports, reports.Count));

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

    private static Mock<ISearchRepository> CreateSearchRepositoryMock(IEnumerable<Domain.Entities.Search> searches)
    {
        var mockRepository = new Mock<ISearchRepository>();

        mockRepository.Setup(repo =>
            repo.ListAllAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(searches);

        return mockRepository;
    }

    private static Mock<ICategoryRepository> CreateCategoryRepositoryMock(IEnumerable<Category> categories)
    {
        var mockRepository = new Mock<ICategoryRepository>();

        mockRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(categories);

        return mockRepository;
    }

    private static Mock<ICountryRepository> CreateCountryRepositoryMock(IEnumerable<Country> countries)
    {
        var mockRepository = new Mock<ICountryRepository>();

        mockRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(countries);

        return mockRepository;
    }
}