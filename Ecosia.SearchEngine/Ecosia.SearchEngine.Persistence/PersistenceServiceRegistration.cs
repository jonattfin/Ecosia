using Ecosia.SearchEngine.Application.Contracts.Persistence;
using Ecosia.SearchEngine.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ecosia.SearchEngine.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<EcosiaDbContext>(options => options.UseInMemoryDatabase(databaseName: "EcosiaDbLocal"));
        // services.AddDbContext<EcosiaDbContext>(options => options.UseSqlite("Data Source=Ecosia.db"));

        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
        
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IReportRepository, ReportRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}