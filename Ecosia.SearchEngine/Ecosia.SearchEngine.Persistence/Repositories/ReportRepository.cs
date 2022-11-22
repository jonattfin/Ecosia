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

    public override async Task<(IEnumerable<Report>, int)> ListAllAsync(int page, int size)
    {
        var items = await GetReportsWithInvestments()
            .Skip((page - 1) * size).Take(size)
            .OrderByDescending(r => r.Year)
            .ThenByDescending(r => r.Month)
            .ToListAsync();

        var count = await GetReportsWithInvestments().CountAsync();

        return (items, count);
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