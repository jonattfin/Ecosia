using System.Collections.Immutable;
using Ecosia.SearchEngine.Domain.Common;
using Ecosia.SearchEngine.Domain.Entities;
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
        var projects = GenerateProjects();
        var reports = GenerateReports();
        
        modelBuilder.Entity<Project>().HasData(projects);
        modelBuilder.Entity<Report>().HasData(reports);
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

    private static IEnumerable<Project> GenerateProjects()
    {
        var random = new Random();

        return Enumerable.Range(1, 20)
            .Select(element => new Project()
            {
                Id = Guid.NewGuid(),
                Name = $"Name {element}",
                Description = $"Description {element}",
                Scope = $"Scope {element}",
                Title = $"Title {element}",
                ImageUrl = $"ImageUrl {element}",
                HectaresRestored = random.Next(100),
                TreesPlanted = random.Next(1000),
                YearSince = random.Next(2010, 2022),
            }).ToImmutableList();
    }
    
     private static IEnumerable<Report> GenerateReports()
     {
         return Enumerable.Range(1, 12).Select(element => new Report()
         {
            Id = Guid.NewGuid(),
            Name = $"Name {element}"
         }).ToImmutableList();
     }
     
}