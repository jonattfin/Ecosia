using Ecosia.SearchEngine.Domain.Common;
using Ecosia.SearchEngine.Domain.Entities;
using Ecosia.SearchEngine.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Ecosia.SearchEngine.Persistence;

public class EcosiaDbContext : DbContext
{
    public DbSet<Project> Projects { get; set; }

    public DbSet<Report> Reports { get; set; }

    public EcosiaDbContext(DbContextOptions<EcosiaDbContext> options) : base(options)
    {
        this.Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Seed();
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    break;
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}