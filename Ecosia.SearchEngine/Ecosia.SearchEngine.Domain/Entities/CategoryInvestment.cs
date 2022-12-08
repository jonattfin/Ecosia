using Ecosia.SearchEngine.Domain.Common;

namespace Ecosia.SearchEngine.Domain.Entities;

public class CategoryInvestment : IEntity
{
    public Guid Id { get; set; }

    public Guid CategoryId { get; set; }
    
    public Guid ReportId { get; set; }

    public double Amount { get; set; }
}