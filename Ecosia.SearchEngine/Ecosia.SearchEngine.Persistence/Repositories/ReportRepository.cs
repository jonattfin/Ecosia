using Ecosia.SearchEngine.Application.Contracts.Persistence;
using Ecosia.SearchEngine.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecosia.SearchEngine.Persistence.Repositories;

public class ReportRepository : BaseRepository<Report>, IReportRepository
{
    public ReportRepository(EcosiaDbContext context) : base(context)
    {
    }

    public override async Task<IReadOnlyList<Report>> ListAllAsync()
    {
        return await _context.Reports
            .Include(report => report.InvestmentsInCategories)
            .Include(report => report.InvestmentsInCountries)
            .ToListAsync();
    }
}