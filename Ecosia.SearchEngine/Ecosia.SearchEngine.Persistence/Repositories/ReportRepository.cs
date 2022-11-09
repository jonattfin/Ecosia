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
        return await _context.Reports
            .Include(report => report.InvestmentsInCategories)
            .Include(report => report.InvestmentsInCountries)
            .AsNoTracking()
            .FirstOrDefaultAsync(project => project.Id == id);
    }

    public override async Task<IReadOnlyList<Report>> ListAllAsync(int page, int size)
    {
        return await _context.Reports
            .Skip((page - 1) * size).Take(size)
            .OrderByDescending(r => r.Year)
            .ThenByDescending(r => r.Month)
            .Include(report => report.InvestmentsInCategories)
            .Include(report => report.InvestmentsInCountries)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Report> GetLast()
    {
        return await _context.Reports
            .Include(report => report.InvestmentsInCategories)
            .Include(report => report.InvestmentsInCountries)
            .AsNoTracking()
            .OrderByDescending(r => r.Year)
            .ThenByDescending(r => r.Month)
            .FirstOrDefaultAsync();
    }
}