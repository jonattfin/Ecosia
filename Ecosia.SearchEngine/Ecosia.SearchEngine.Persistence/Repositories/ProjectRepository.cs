using Ecosia.SearchEngine.Application.Contracts.Persistence;
using Ecosia.SearchEngine.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecosia.SearchEngine.Persistence.Repositories;

public class ProjectRepository : BaseRepository<Project>, IProjectRepository
{
    public ProjectRepository(EcosiaDbContext context) : base(context)
    {
    }

    public override async Task<Project> GetByIdAsync(Guid id)
    {
        return await GetProjectsWithTags()
            .FirstOrDefaultAsync(project => project.Id == id);
    }

    public override async Task<(IEnumerable<Project>, int)> ListAllAsync(int page, int size)
    {
        var items = await GetProjectsWithTags().Skip((page - 1) * size).Take(size)
            .OrderByDescending(p => p.YearSince)
            .ToListAsync();

        var count = await GetProjectsWithTags().CountAsync();

        return (items, count);
    }

    private IQueryable<Project> GetProjectsWithTags()
    {
        return _context.Projects.Include(project => project.Tags)
            .AsNoTracking();
    }
}