using Ecosia.SearchEngine.Application.Contracts.Persistence;
using Ecosia.SearchEngine.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecosia.SearchEngine.Persistence.Repositories;

public class ReportRepository : BaseRepository<Report>, IReportRepository
{
    public ReportRepository(EcosiaDbContext context) : base(context)
    {
    }

    public override async Task<Report> GetByIdAsync(Guid id)
    {
        return await GetReportsWithInvestments()
            .FirstOrDefaultAsync(project => project.Id == id);
    }

    public override async Task<IReadOnlyList<Report>> ListAllAsync(int page, int size)
    {
        return await GetReportsWithInvestments()
            .Skip((page - 1) * size).Take(size)
            .OrderByDescending(r => r.Year)
            .ThenByDescending(r => r.Month)
            .ToListAsync();
    }

    public async Task<Report> GetLast()
    {
        return await GetReportsWithInvestments()
            .OrderByDescending(r => r.Year)
            .ThenByDescending(r => r.Month)
            .FirstOrDefaultAsync();
    }

    private IQueryable<Report> GetReportsWithInvestments()
    {
        return _context.Reports
            .Include(report => report.InvestmentsInCategories)
            .Include(report => report.InvestmentsInCountries)
            .AsNoTracking();
    }
}