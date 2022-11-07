using Ecosia.SearchEngine.Application.Contracts.Persistence;
using Ecosia.SearchEngine.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecosia.SearchEngine.Persistence.Repositories;

public class ProjectRepository : BaseRepository<Project>, IProjectRepository
{
    public ProjectRepository(EcosiaDbContext context) : base(context)
    {
    }

    public override async Task<IReadOnlyList<Project>> ListAllAsync()
    {
        return await _context.Projects.Include(project => project.Tags).ToListAsync();
    }
}