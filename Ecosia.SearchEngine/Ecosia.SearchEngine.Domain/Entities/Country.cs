using Ecosia.SearchEngine.Domain.Common;

namespace Ecosia.SearchEngine.Domain.Entities;

public class Country : IEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }
}