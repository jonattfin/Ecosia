using Ecosia.SearchEngine.Application.Contracts.Persistence;
using Ecosia.SearchEngine.Domain.Entities;

namespace Ecosia.SearchEngine.Persistence.Repositories;

public class ReportRepository : BaseRepository<Report>, IReportRepository
{
    public ReportRepository(EcosiaDbContext context) : base(context)
    {
    }
}