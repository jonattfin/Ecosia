namespace Ecosia.SearchEngine.Application.Features.Projects.Queries;

public class PagedProjectsListVm
{
    public int Page { get; set; }
    public int Size { get; set; }
    public int Count { get; set; }
    public List<ProjectListVm> Projects { get; set; }
}

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
    
    public List<TagListVm> Tags { get; set; }
}

public class TagListVm
{
    public string Title { get; set; }
    public string Subtitle { get; set; }
}