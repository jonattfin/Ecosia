using Ecosia.SearchEngine.Application.Contracts.Persistence;

namespace Ecosia.SearchEngine.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly EcosiaDbContext _context;

    public UnitOfWork(EcosiaDbContext context, IProjectRepository projectRepository, IReportRepository reportRepository,
        ICategoryRepository categoryRepository, ICountryRepository countryRepository)
    {
        _context = context;

        ProjectRepository = projectRepository;
        ReportRepository = reportRepository;
        CategoryRepository = categoryRepository;
        CountryRepository = countryRepository;
    }

    public IProjectRepository ProjectRepository { get; }
    public IReportRepository ReportRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    public ICountryRepository CountryRepository { get; }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}