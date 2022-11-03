namespace Ecosia.SearchEngine.Application.Features.Projects.Queries;

public class ProjectListVm
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }

    public string Scope { get; set; }

    public string Description { get; set; }

    public string Title { get; set; }

    public int? TreesPlanted { get; set; }

    public int? HectaresRestored { get; set; }

    public int? YearSince { get; set; }

    public string ImageUrl { get; set; }
}