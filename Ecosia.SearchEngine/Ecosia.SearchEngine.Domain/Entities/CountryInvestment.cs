using Ecosia.SearchEngine.Domain.Common;

namespace Ecosia.SearchEngine.Domain.Entities;

public class CountryInvestment : IEntity
{
    public Guid Id { get; set; }

    public Guid CountryId { get; set; }
    
    public Guid ReportId { get; set; }

    public double Amount { get; set; }
}