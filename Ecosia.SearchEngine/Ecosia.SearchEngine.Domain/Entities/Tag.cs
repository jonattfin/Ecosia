using Ecosia.SearchEngine.Domain.Common;

namespace Ecosia.SearchEngine.Domain.Entities;

public class Tag : AuditableEntity
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Subtitle { get; set; }
}