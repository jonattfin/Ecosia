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
        return await _context.Projects.Include(project => project.Tags)
            .AsNoTracking()
            .FirstOrDefaultAsync(project => project.Id == id);
    }

    public override async Task<IReadOnlyList<Project>> ListAllAsync(int page, int size)
    {
        return await _context.Projects.Skip((page - 1) * size).Take(size).Include(project => project.Tags)
            .AsNoTracking().ToListAsync();
    }
}