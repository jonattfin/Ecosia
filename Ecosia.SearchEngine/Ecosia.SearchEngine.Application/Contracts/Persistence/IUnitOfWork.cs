namespace Ecosia.SearchEngine.Application.Contracts.Persistence;

public interface IUnitOfWork
{
    IProjectRepository ProjectRepository { get; }
    IReportRepository ReportRepository { get; }
    
    ICategoryRepository CategoryRepository { get; }
    
    ICountryRepository CountryRepository { get; }
    
    Task SaveChangesAsync();
}