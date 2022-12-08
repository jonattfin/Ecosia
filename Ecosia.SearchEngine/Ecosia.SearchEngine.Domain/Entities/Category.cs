using Ecosia.SearchEngine.Domain.Common;

namespace Ecosia.SearchEngine.Domain.Entities;

public class Category : IEntity
{
    public string Name { get; set; }
    public Guid Id { get; set; }
}