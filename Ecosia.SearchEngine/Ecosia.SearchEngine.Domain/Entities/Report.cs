using Ecosia.SearchEngine.Domain.Common;

namespace Ecosia.SearchEngine.Domain.Entities;

public class Report : AuditableEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}